using MWShare.Controllers;
using MWShare.FilterAttributes;
using CommonLib.Constants;
using DataAccess.Helpers;
using Microsoft.AspNetCore.Mvc;
using Business.Core.Services.BaseServices;
using Object.Core;
using CommonLib;
using MemoryData;
using Microsoft.AspNetCore.Http.Extensions;
using static CommonLib.Constants.Const;
using System.Reflection;
using MWShare.Helpers;
using Business.Core.Services.FreelancerServices;
using Business.Core.BLs.JobBLs;
using Business.Core.Services.JobServices;

namespace MWCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.Job)]
    public class FreelancerController : ControllerBase
    {
        private readonly IFreelancerService _freelancerService;

        public string RequestId => LoggingManagement.RequestId;
        private readonly ILoggingManagement LoggingManagement;
        public FreelancerController(ILoggingManagement loggingManagement, IFreelancerService freelancerService)
        {
            LoggingManagement = loggingManagement;
            _freelancerService = freelancerService;
        }

        [HttpPut("updateisopenforjob")]
        public async Task<MasterDataBaseBusinessResponse> UpdateIsOpenForJob([FromBody] MWFreelancer data)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            MasterDataBaseBusinessResponse response = new();

            try
            {
                var result = await Task.Run(() =>
                {
                    var createResult = _freelancerService.UpdateIsOpenForJob(data, clientInfo, out var createResMessage);
                    return new Tuple<long, string>(createResult, createResMessage);
                });

                //
                response.Code = result.Item1;
                response.Message = !string.IsNullOrEmpty(result.Item2) ? result.Item2 : DefErrorMem.GetErrorDesc(result.Item1, clientInfo.ClientLanguage);

                if (response.Code <= 0)
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                }
                else
                {
                    response.Id = $"{data.FreelancerId}";
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{RequestId}] {ex.Message}");

                response.Code = ErrorCodes.Err_Exception;
                response.Message = ex.Message;

                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                RequestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = ConstLog.GetProcessingMilliseconds(requestTime),
                peer = clientInfo?.IpAddress,
                request = data,
            }));

            return response;
        }
    }

}
