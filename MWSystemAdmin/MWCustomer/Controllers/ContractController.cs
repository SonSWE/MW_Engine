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

namespace MWCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.Job)]
    [MasterDataBaseControllerConfig("CONTRACT", Const.ProfileKeyField.Contract)]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;
        private readonly IMasterDataBaseService<MWContract> MasterDataBaseService;
        public readonly ILoggingManagement LoggingManagement;
        public string RequestId => LoggingManagement.RequestId;
        public ContractController(IMasterDataBaseService<MWContract> masterDataBaseBL, ILoggingManagement loggingManagement, IContractService contractService)
        {
            _contractService = contractService;
            LoggingManagement = loggingManagement;
            MasterDataBaseService = masterDataBaseBL;
        }


        //
        [ApiAuthorize(Action = Const.AuthenAction.Query)]
        [HttpGet("getdetailbyid")]
        public async Task<MWContract?> GetDetailById([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            MWContract? response = null;

            try
            {
                response = await Task.Run(() => MasterDataBaseService.GetDetailById(value));

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


        [ApiAuthorize(Action = Const.AuthenAction.Add)]
        [HttpPost("sendoffer")]
        public async Task<MasterDataBaseBusinessResponse> SendOffer([FromBody] MWContract data)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            MasterDataBaseBusinessResponse response = new();

            try
            {
                var result = await Task.Run(() =>
                {
                    var createResult = _contractService.SendOffer(data, clientInfo, out var createResMessage, out var propertyName);
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
                    response.Id = $"{data.ContractId}";
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

        [HttpPut("updatestatus")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> UpdateStatus([FromBody] MasterDataBaseApproveRequest data)
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
                    var createResult = _contractService.UpdateStatus(data.Id, data.Status, data.Des, clientInfo, out var createResMessage, out var propertyName);
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
                    response.Id = $"{data.Id}";
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

        [HttpPost("submitcontact")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> SubmitContact([FromBody] MWContractResult data)
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
                    var createResult = _contractService.SubmitContractResult(data, clientInfo, out var createResMessage);
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
                    response.Id = $"{data.ContractId}";
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

        [HttpPost("paymentcontract")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> PaymentContract([FromQuery] string value)
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
                    var createResult = _contractService.PaymentContract(value, clientInfo, out var resMessage);
                    return new Tuple<long, string>(createResult, resMessage);
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
                    response.Id = $"{value}";
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
                request = value,
            }));

            return response;
        }

        [HttpGet("getbyfreelancer")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<List<MWContract>?> GetContractByFreelancer([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            List<MWContract>? response = null;

            try
            {
                response = await Task.Run(() => _contractService.GetContractByFreelancer(value));

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

        [HttpGet("getbyjobid")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<List<MWContract>?> GetContractByJobId([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            List<MWContract>? response = null;

            try
            {
                response = await Task.Run(() => _contractService.GetContractByJobId(value));

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

        [HttpGet("getcontractresult")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<List<MWContractResult>?> GetContractResultByContractId([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            List<MWContractResult>? response = null;

            try
            {
                response = await Task.Run(() => _contractService.GetContractResultByContractId(value));

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

        [HttpPost("donecontract")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> DoneContract([FromBody] MWFeedBack data)
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
                    var createResult = _contractService.DoneContract(data, clientInfo, out var createResMessage);
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
                    response.Id = $"{data.ContractId}";
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

        [HttpPost("endcontract")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> EndContract([FromBody] MWContract data)
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
                    var createResult = _contractService.EndContract(data, clientInfo, out var createResMessage);
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
                    response.Id = $"{data.ContractId}";
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
