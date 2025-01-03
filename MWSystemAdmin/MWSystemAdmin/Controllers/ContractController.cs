using MWShare.Controllers;
using MWShare.FilterAttributes;
using CommonLib.Constants;
using DataAccess.Helpers;
using Microsoft.AspNetCore.Mvc;
using Business.Core.Services.BaseServices;
using Object.Core;
using CommonLib;
using Microsoft.AspNetCore.Http.Extensions;
using MWShare.Helpers;
using System.Reflection;
using Business.Core.Services.ProposalServices;
using MemoryData;
using Business.Core.Services.ContractServices;
using Business.Core.BLs.BaseBLs;
using Business.Core.Validators;
using DataAccess.Core.Helpers;
using System.Data;
using CommonLib.Extensions;
using Object;

namespace BOSystemAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.Job)]
    [MasterDataBaseControllerConfig("CONTRACT", Const.ProfileKeyField.Contract)]
    public class ContractController : MasterDataBaseController<MWContract>
    {
        private readonly IContractService _contractService;
        public ContractController(IMasterDataBaseService<MWContract> masterDataBaseBL, ILoggingManagement loggingManagement, IContractService contractService) : base(masterDataBaseBL, loggingManagement)
        {
            _contractService = contractService;
        }

        [HttpPost("approvalcontractcomplaint")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> ApprovalContractComplaint([FromQuery] string id, [FromQuery] string status)
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
                    var createResult = _contractService.ApprovalContractComplaint(id, status, clientInfo, out var createResMessage);
                    return new Tuple<long, string>(createResult, createResMessage);
                });

                //
                response.Code = result.Item1;
                response.Message = !string.IsNullOrEmpty(result.Item2) ? result.Item2 : DefErrorMem.GetErrorDesc(result.Item1, clientInfo.ClientLanguage);
                response.PropertyName = string.Empty;

                if (response.Code <= 0)
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                }
                else
                {
                    response.Id = $"{id}";
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
                request = id,
            }));

            return response;
        }
    }

}
