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
using Business.Core.Services.JobServices;
using MemoryData;
using System.Reflection;
using CommonLib.Extensions;
using Object;
using Google.Protobuf.WellKnownTypes;

namespace MWCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.Job)]
    [MasterDataBaseControllerConfig("JOB", Const.ProfileKeyField.Job)]
    public class JobController : MasterDataBaseController<MWJob>
    {
        private readonly IJobService _jobService;
        private readonly IJobSavedService _jobSavedService;
        public JobController(IMasterDataBaseService<MWJob> masterDataBaseBL, ILoggingManagement loggingManagement, IJobService jobService, IJobSavedService jobSavedService) : base(masterDataBaseBL, loggingManagement)
        {
            _jobService = jobService;
            _jobSavedService = jobSavedService;
        }

        [HttpGet("getsuggestbyfreelancer")]
        public virtual async Task<List<MWJob>?> GetSuggestByFreelancer([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            List<MWJob>? response = null;

            try
            {
                response = await Task.Run(() => _jobService.GetSuggestByFreelancer(value, clientInfo));

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


        [HttpGet("getsavedjobs")]
        public virtual async Task<List<MWJob>?> GetSavedJobsByFreelancer([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            List<MWJob>? response = null;

            try
            {
                response = await Task.Run(() => _jobSavedService.GetSavedJobsByFreelancer(value, clientInfo));

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

        [HttpPost("insertsavejob")]
        public virtual async Task<MasterDataBaseBusinessResponse> InsertSaveJob([FromBody] MWJobSaved data)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            MasterDataBaseBusinessResponse response = new();

            try
            {
                var result = await Task.Run(() =>
                {
                    var createResult = _jobSavedService.InsertData(data, clientInfo, out var createResMessage);
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

            return response;
        }


        [HttpDelete("removesavejob")]
        public virtual async Task<MasterDataBaseBusinessResponse> RemoveSaveJob([FromBody] MWJobSaved data)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            MasterDataBaseBusinessResponse response = new();

            try
            {
                var result = await Task.Run(() =>
                {
                    var createResult = _jobSavedService.DeleteData(data, clientInfo, out var createResMessage);
                    return new Tuple<long, string>(createResult, createResMessage);
                });
                response.Code = result.Item1;
                response.Message = result.Item2;

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

            return response;
        }

        //client
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        [HttpGet("getbyclientid")]
        public virtual async Task<List<MWJob>?> GetByClientId([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            List<MWJob>? response = null;

            try
            {
                response = await Task.Run(() => _jobService.GetByClientId(value, clientInfo));

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


        [HttpPost, Route("search")]
        public async Task<List<MWJob>?> Search([FromBody] SearchJobRequest data)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();
            List<MWJob>? response = null;

            try
            {
                response = await Task.Run(() => _jobService.Search(data, clientInfo));

            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{RequestId}] {ex.Message}");
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
