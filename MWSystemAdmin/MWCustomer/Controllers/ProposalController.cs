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

namespace MWCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.Job)]
    [MasterDataBaseControllerConfig("PROPOSAL", Const.ProfileKeyField.Proposal)]
    public class ProposalController : MasterDataBaseController<MWProposal>
    {
        private readonly IProposalService _proposalService;
        public ProposalController(IMasterDataBaseService<MWProposal> masterDataBaseBL, ILoggingManagement loggingManagement, IProposalService proposalService) : base(masterDataBaseBL, loggingManagement)
        {
            _proposalService = proposalService;
        }

        [HttpPost("add")]
        public override async Task<MasterDataBaseBusinessResponse> Create([FromBody] MWProposal data)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            MasterDataBaseBusinessResponse response = new();

            try
            {
                var result = await Task.Run(() =>
                {
                    data.Status = Const.Proposal_Status.Sent;
                    var createResult = MasterDataBaseService.Create(data, clientInfo, out var createResMessage, out var propertyName);
                    return new Tuple<long, string, string>(createResult, createResMessage, propertyName);
                });

                //
                response.Code = result.Item1;
                response.Message = !string.IsNullOrEmpty(result.Item2) ? result.Item2 : DefErrorMem.GetErrorDesc(result.Item1, clientInfo.ClientLanguage);
                response.PropertyName = result.Item3 ?? string.Empty;

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


        [HttpGet("getproposalbyfreelancerid")]
        public virtual async Task<List<MWProposal>?> GetProposalByFreelancerId([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            List<MWProposal>? response = null;

            try
            {
                response = await Task.Run(() => _proposalService.GetProposalByFreelancer(value));

                if (response == null)
                {
                    Response.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{RequestId}] {ex.Message}");

                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                RequestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = ConstLog.GetProcessingMilliseconds(requestTime),
                peer = clientInfo?.IpAddress,
                request = new { value },
            }));

            return response;
        }


        [HttpGet("getproposalbyjobid")]
        public virtual async Task<List<MWProposal>?> GetProposalByJobId([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            List<MWProposal>? response = null;

            try
            {
                response = await Task.Run(() => _proposalService.GetProposalByJobId(value));

                if (response == null)
                {
                    Response.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{RequestId}] {ex.Message}");

                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                RequestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = ConstLog.GetProcessingMilliseconds(requestTime),
                peer = clientInfo?.IpAddress,
                request = new { value },
            }));

            return response;
        }

    }

}
