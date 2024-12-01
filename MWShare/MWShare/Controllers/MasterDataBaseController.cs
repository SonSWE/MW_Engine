using MWShare.FilterAttributes;
using MWShare.Helpers;
using Business.Core;
using CommonLib;
using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Helpers;
using LogStation;
using MemoryData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Object.Core;
using System.Reflection;
using Business.Core.Services.BaseServices;

namespace MWShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataBaseController<T> : ControllerBase where T : MasterDataBase, new()
    {
        public string FunctionId => GetApiAuthorizeFunctionConfig()?.FunctionId ?? string.Empty;
        public string NotifyKey => GetMasterDataBaseControllerConfigAttribute()?.NotifyKey ?? string.Empty;
        public string ProfileKeyField => GetMasterDataBaseControllerConfigAttribute()?.ProfileKeyField ?? string.Empty;
        public string RequestId => LoggingManagement.RequestId;

        public readonly IMasterDataBaseService<T> MasterDataBaseService;
        public readonly ILoggingManagement LoggingManagement;

        public MasterDataBaseController(IMasterDataBaseService<T> masterDataBaseService, ILoggingManagement loggingManagement)
        {
            MasterDataBaseService = masterDataBaseService;
            LoggingManagement = loggingManagement;
        }

        //
        //[ApiAuthorize(Action = Const.AuthenAction.Query)]
        [HttpGet("getdetailbyid")]
        public virtual async Task<T?> GetDetailById([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            T? response = null;

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

            LogStationFacade.RecordforPT(ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod()), DateTime.Now.Subtract(requestTime).Ticks, true);

            return response;
        }

        //
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        [HttpGet("checkduplicateid")]
        public virtual async Task<MasterDataBaseCheckDuplicateIdResponse?> CheckDuplicateId([FromQuery] string? value)
        {
            var clientInfo = Request.GetClientInfo();
            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            try
            {
                var response = await Task.Run(() => MasterDataBaseService.CheckDuplicateId(value ?? string.Empty));

                //if (response != null && response.IsDuplicated)
                //{
                //    Response.StatusCode = StatusCodes.Status400BadRequest;
                //}

                return response;
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{RequestId}] {ex.Message}");

                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            return new();
        }

        // Create
        //[ApiAuthorize(Action = Const.AuthenAction.Add)]
        [HttpPost("add")]
        public virtual async Task<MasterDataBaseBusinessResponse> Create([FromBody] T data)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            MasterDataBaseBusinessResponse response = new();

            try
            {
                var result = await Task.Run(() =>
                {
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
                    response.Id = $"{data.GetPropertyValue(ProfileKeyField)}";
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

            LogStationFacade.RecordforPT(ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod()), DateTime.Now.Subtract(requestTime).Ticks, true);

            return response;
        }

        // Update
        //[ApiAuthorize(Action = Const.AuthenAction.Update)]
        [HttpPut("update")]
        public virtual async Task<MasterDataBaseBusinessResponse> Update([FromBody] T data)
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
                    var createResult = MasterDataBaseService.Update(data, clientInfo, out var createResMessage, out var propertyName);
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
                    response.Id = $"{data.GetPropertyValue(ProfileKeyField)}";
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

            LogStationFacade.RecordforPT(ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod()), DateTime.Now.Subtract(requestTime).Ticks, true);

            return response;
        }

        // Delete
        //[ApiAuthorize(Action = Const.AuthenAction.Delete)]
        [HttpDelete("delete")]
        public virtual async Task<MasterDataBaseBusinessResponse> Delete([FromBody] MasterDataBaseDeleteRequest data)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            MasterDataBaseBusinessResponse response = new();

            try
            {
                var result = await Task.Run(() => MasterDataBaseService.Delete(data.Id, clientInfo));

                response.Code = result;
                response.Message = DefErrorMem.GetErrorDesc(result, clientInfo.ClientLanguage);

                if (result <= 0)
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                }
                else
                {
                    response.Id = $"{data.GetPropertyValue(ProfileKeyField)}";
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{RequestId}] {ex.Message}");

                response.Code = ErrorCodes.Err_Exception;
                response.Message = DefErrorMem.GetErrorDesc(ErrorCodes.Err_Exception, clientInfo.ClientLanguage);

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

            LogStationFacade.RecordforPT(ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod()), DateTime.Now.Subtract(requestTime).Ticks, true);

            return response;
        }

        // Private Funcs
        #region Private Funcs

        private ApiAuthorizeFunctionConfigAttribute? GetApiAuthorizeFunctionConfig()
        {
            var attributes = this.GetType().GetCustomAttributes(typeof(ApiAuthorizeFunctionConfigAttribute), true);

            if (attributes != null && attributes.Length > 0)
            {
                return (ApiAuthorizeFunctionConfigAttribute)attributes[0];
            }

            return null;
        }

        private MasterDataBaseControllerConfigAttribute? GetMasterDataBaseControllerConfigAttribute()
        {
            var attributes = this.GetType().GetCustomAttributes(typeof(MasterDataBaseControllerConfigAttribute), true);

            if (attributes != null && attributes.Length > 0)
            {
                return (MasterDataBaseControllerConfigAttribute)attributes[0];
            }

            return null;
        }
        #endregion
    }
}
