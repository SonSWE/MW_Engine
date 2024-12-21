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
using Business.Core.Services.WalletServices;
using Object;

namespace MWCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.Job)]
    [MasterDataBaseControllerConfig("WALLET", Const.ProfileKeyField.Wallet)]
    public class WalletController : MasterDataBaseController<MWWallet>
    {
        private readonly IWalletService _walletService;
        public WalletController(IMasterDataBaseService<MWWallet> masterDataBaseBL, ILoggingManagement loggingManagement,
            IWalletService walletService) : base(masterDataBaseBL, loggingManagement)
        {
            _walletService = walletService;
        }

        [HttpPost("deposit")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> Deposit([FromBody] MWTransaction data)
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
                    var createResult = _walletService.Deposit(data, clientInfo, out var createResMessage);
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
                    response.Id = $"{data.TransactionId}";
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

        [HttpPost("withdraw")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> Withdraw([FromBody] MWTransaction data)
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
                    var createResult = _walletService.Withdraw(data, clientInfo, out var createResMessage);
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
                    response.Id = $"{data.TransactionId}";
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

        [HttpPost("transfer")]
        [ApiAuthorize(Action = Const.AuthenAction.Any)]
        public async Task<MasterDataBaseBusinessResponse> Transfer([FromBody] MWTransaction data)
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
                    var createResult = _walletService.Transfer(data, clientInfo, out var createResMessage);
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
                    response.Id = $"{data.TransactionId}";
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

        [HttpGet("getdetailbyusername")]
        public virtual async Task<MWWallet> GetDetailByUserName([FromQuery] string? value)
        {
            var requestTime = DateTime.Now;
            var clientInfo = Request.GetClientInfo();

            Logger.logData.Info($"[{RequestId}] Receive request from [{clientInfo?.IpAddress}] url=[{Request.GetDisplayUrl()}]");

            //
            MWWallet? response = null;

            try
            {
                response = await Task.Run(() => _walletService.GetDetailByUserName(value));

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
