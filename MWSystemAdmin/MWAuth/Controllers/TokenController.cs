using MWAuth.Extensions;
using MWAuth.Filters;
using MWAuth.Helpers;
using MWAuth.MemoryData;
using MWAuth.Models;
using CommonLib;
using CommonLib.Constants;
using MemoryData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Object.Core;
using Object.Core.Share;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Core.Services.LoginServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
namespace MWAuth.Controllers.SA
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class TokenController : ControllerBase
    {
        // some config in the appsettings.json
        private IOptions<Audience> c_settings;
        private readonly ILoginService _loginService;

        private readonly string c_userNameAdmin = EncryptData.DecryptAES(ConfigDataAuth.AdminAccount["UserName"] ?? string.Empty, ConfigDataAuth.AES_Key, ConfigDataAuth.AES_IV);
        private readonly string c_passwordAdmin = EncryptData.DecryptAES(ConfigDataAuth.AdminAccount["Password"] ?? string.Empty, ConfigDataAuth.AES_Key, ConfigDataAuth.AES_IV);

        private bool isAdmin = false;

        public TokenController(IOptions<Audience> settings, ILoginService loginService)
        {
            c_settings = settings;
            _loginService = loginService;
        }

        [HttpPost("logout")]
        public IActionResult Logout(TokenRequestParams parameters)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();

            var responseCode = StatusCodes.Status204NoContent;
            object responseData;

            try
            {
                if (parameters != null && !string.IsNullOrEmpty(parameters?.Refresh_token))
                {
                    LoginMem.RemoveRefreshToken(parameters.Refresh_token);
                }

                responseCode = StatusCodes.Status200OK;
                responseData = new BaseInfo() { Code = 1, Message = "_" };
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{requestId}] {ex.Message}");

                responseCode = StatusCodes.Status500InternalServerError;
                responseData = ex.Message;
            }

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { parameters?.Refresh_token },
            }));

            return StatusCode(responseCode, responseData);
        }

        [HttpGet("checkalive")]
        [FunctionAuthorizeFilter(CheckRight = false)]
        public IActionResult CheckAlive()
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();
            var userInfo = Request.GetUserInfo();

            var responseCode = StatusCodes.Status204NoContent;
            LoggedUser responseData = null;

            if (userInfo != null && !string.IsNullOrEmpty(userInfo.UserName))
            {
                responseCode = StatusCodes.Status200OK;

                responseData = LoginMem.GetLoggedUserFromUser(LoginMem.GetUser(userInfo.UserName));
            }
            else
            {
                responseCode = StatusCodes.Status401Unauthorized;
            }

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { },
            }));

            return StatusCode(responseCode, responseData);
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth(TokenRequestParams parameters)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();

            var responseCode = StatusCodes.Status400BadRequest;
            object responseData = null;

            try
            {
                if (parameters == null)
                {
                    responseCode = StatusCodes.Status400BadRequest;
                    goto endFunc;
                }

                if (string.Equals(c_userNameAdmin, parameters.Username, StringComparison.OrdinalIgnoreCase))
                {
                    isAdmin = true;
                }

                if (parameters.Grant_type == "password")
                {
                    return await DoPassword(parameters);
                }
                else if (parameters.Grant_type == "refresh_token")
                {
                    return await DoRefreshToken(parameters);
                }
                else if (parameters.Grant_type == "invalidate_token")
                {
                    return DoInvalidateToken(parameters);
                }
                else
                {
                    responseCode = StatusCodes.Status400BadRequest;
                    responseData = new BaseInfo() { Code = -1, Message = "Invalid grant type" };
                    goto endFunc;
                }

            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{requestId}] {ex.Message}");

                responseCode = StatusCodes.Status500InternalServerError;
                responseData = new BaseInfo() { Code = -1, Message = ex.Message };
            }

        //
        endFunc:

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { parameters },
            }));

            return StatusCode(responseCode, responseData);
        }

        [HttpPost("verify")]
        public IActionResult Verify([FromBody] VerifyTokenModel model)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();
            var userInfo = Request.GetUserInfo();

            var responseCode = StatusCodes.Status204NoContent;
            object responseData = null;

            try
            {
                if (model == null || string.IsNullOrEmpty(model.Token))
                {
                    responseCode = StatusCodes.Status400BadRequest;
                    goto endFunc;
                }

                var token = model.Token?.StartsWith("Bearer ") == true ? model.Token.Substring(7) : model.Token;
                var user = JWTHelper.ValidateTokenAndGetUserInfo(token);
                if (user == null || string.IsNullOrEmpty(user.UserName))
                {
                    responseCode = StatusCodes.Status401Unauthorized;
                    goto endFunc;
                }

                //
                responseCode = StatusCodes.Status200OK;
                responseData = LoginMem.GetLoggedUserFromUser(user);
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{requestId}] {ex.Message}");

                responseCode = StatusCodes.Status500InternalServerError;
                responseData = ex.Message;
            }

        //
        endFunc:

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { model },
            }));

            return StatusCode(responseCode, responseData);
        }

        [HttpPost("verify-token-and-function")]
        public IActionResult VerifyTokenAndFunction([FromBody] VerifyTokenAndFunctionModel model)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();
            var userInfo = Request.GetUserInfo();

            var responseCode = StatusCodes.Status204NoContent;
            object responseData = null;

            try
            {
                if (model == null || string.IsNullOrEmpty(model.Token))
                {
                    responseCode = StatusCodes.Status400BadRequest;
                    goto endFunc;
                }

                var token = model.Token?.StartsWith("Bearer ") == true ? model.Token.Substring(7) : model.Token;
                var user = JWTHelper.ValidateTokenAndGetUserInfo(token);
                if (user == null || string.IsNullOrEmpty(user.UserName))
                {
                    responseCode = StatusCodes.Status401Unauthorized;
                    goto endFunc;
                }

                //if (model.CheckFunction)
                //{
                //    if (!LoginMem.ValidateFunctionPermission(user.UserName, model.FunctionId.Split(","), model.Action.Split(","), model.CheckMode))
                //    {
                //        responseCode = StatusCodes.Status403Forbidden;
                //        goto endFunc;
                //    }
                //}

                //
                responseCode = StatusCodes.Status200OK;
                responseData = LoginMem.GetLoggedUserFromUser(user);
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{requestId}] {ex.Message}");

                responseCode = StatusCodes.Status500InternalServerError;
                responseData = ex.Message;
            }

        //
        endFunc:

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { model },
            }));

            return StatusCode(responseCode, responseData);
        }

        [HttpPost("verify-function")]
        public IActionResult VerifyFunction([FromBody] VerifyFunctionModel model)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();
            var userInfo = Request.GetUserInfo();

            var responseCode = StatusCodes.Status204NoContent;
            object responseData = null;

            try
            {
                if (model == null)
                {
                    responseCode = StatusCodes.Status400BadRequest;
                    goto endFunc;
                }

                if (!LoginMem.ValidateFunctionPermission(model.UserName, model.FunctionId.Split(","), model.Action.Split(","), model.CheckMode))
                {
                    responseCode = StatusCodes.Status403Forbidden;
                    goto endFunc;
                }

                //
                responseCode = StatusCodes.Status200OK;
                responseData = model;
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{requestId}] {ex.Message}");

                responseCode = StatusCodes.Status500InternalServerError;
                responseData = ex.Message;
            }

        //
        endFunc:

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { model },
            }));

            return StatusCode(responseCode, responseData);
        }

        #region Private funcs

        private IActionResult DoInvalidateToken(TokenRequestParams parameters)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();

            var responseCode = StatusCodes.Status400BadRequest;
            object responseData = null;

            //
            var token = LoginMem.GetRefreshToken(parameters.Refresh_token);

            if (token == null)
            {
                responseCode = StatusCodes.Status400BadRequest;
                responseData = new BaseInfo() { Code = -1, Message = "Token invalid." };
                goto endFunc;
            }

            if (token.IsExpired)
            {
                LoginMem.RemoveRefreshToken(token.RefreshToken);

                responseCode = StatusCodes.Status400BadRequest;
                responseData = new BaseInfo() { Code = -1, Message = "Token has expired." };
                goto endFunc;
            }

            responseCode = StatusCodes.Status200OK;
            responseData = new BaseInfo() { Code = 1, Message = "Token valid." };

        //
        endFunc:

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { parameters },
            }));

            return StatusCode(responseCode, responseData);
        }

        private async Task<IActionResult> DoPassword(TokenRequestParams parameters)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();

            var responseCode = StatusCodes.Status400BadRequest;
            object responseData = null;


            string messageFailedLogonCount = "Số lần đăng nhập sai";


            ////
            var user = await _loginService.GetUserByUserNameAsync(parameters.Username);


            if (user == null || string.IsNullOrEmpty(user.UserName))
            {
                responseCode = StatusCodes.Status400BadRequest;
                responseData = new BaseInfo
                {
                    Code = ErrorCodes.Err_Unknown,
                    Message = $"Không tìm thấy tài khoản trong hệ thống."
                };
                goto endFunc;
            }

            if (!string.Equals(parameters.Password, user.Password))
            {
                LoginMem.UpdateUserLoginState(parameters.Username, browserInfo.Ip, true, out var failedLogonCount, out var maximumLogonFailureCount);

                responseCode = StatusCodes.Status401Unauthorized;
                responseData = new BaseInfo
                {
                    Code = ErrorCodes.Err_Unknown,
                    Message = $"Mật khẩu không chính xác. {messageFailedLogonCount} {failedLogonCount}/{maximumLogonFailureCount}"
                };

                goto endFunc;
            }

            // Check user có bị khóa hay không
            if (string.Equals(user.AccountIsLockedOut, Const.YN.Yes) || !string.Equals(user.Status, "A"))
            {
                responseCode = StatusCodes.Status400BadRequest;
                responseData = new BaseInfo
                {
                    Code = ErrorCodes.Err_InvalidData,
                    Message = "Tài khoản đã bị khóa, hoặc không có quyền đăng nhập vào hệ thống.",
                };
                goto endFunc;
            }

            MWUser userDetail = await _loginService.GetDetailUserAsync(user.UserName);
            //store the sauser
            LoginMem.SetUser(userDetail);

            LoginMem.UpdateUserLoginState(userDetail.UserName, browserInfo.Ip, false, out _, out _);

            //
            var now = DateTime.UtcNow;
            var refresh_token = new IdentityRefreshToken
            {
                Identity = user.UserName,
                RefreshToken = Guid.NewGuid().ToString("N"),
                IssueTimeUtc = DateTime.UtcNow,
                ExpiryTimeUtc = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Utc).AddDays(1),
            };

            var returnValue = await GetJwtAsync(requestId, refresh_token.RefreshToken, userDetail);

            //store the refresh_token
            refresh_token.AccessToken = returnValue.Item2;
            LoginMem.SetRefreshToken(refresh_token);

            //
            Logger.log.Info($"Time: \"{DateTime.Now:O}\". User login: \"{userDetail.UserName}\". User type: \"{userDetail.LoginTypeText}\". Ip \"{browserInfo.Ip}\"");

            responseCode = StatusCodes.Status200OK;
            responseData = returnValue.Item1;

        //
        endFunc:

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { parameters },
            }));

            return StatusCode(responseCode, responseData);
        }

        //scenario 2： get the access_token by refresh_token
        private async Task<IActionResult> DoRefreshToken(TokenRequestParams parameters)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();

            var responseCode = StatusCodes.Status400BadRequest;
            object responseData = null;

            //
            var authorizations = Request.Headers.Authorization;
            string accessToken = string.Empty;
            if (authorizations.Count > 0)
            {
                accessToken = (authorizations[0] ?? string.Empty).Replace("Bearer ", "");
            }

            var token = LoginMem.GetRefreshToken(parameters.Refresh_token);

            if (token == null)
            {
                responseCode = StatusCodes.Status400BadRequest;
                responseData = new BaseInfo
                {
                    Code = -1,
                    Message = "Refresh Token not found."
                };
                goto endFunc;
            }

            if (token.IsExpired)
            {
                // Remove refresh token if expired
                LoginMem.RemoveRefreshToken(token.RefreshToken);

                responseCode = StatusCodes.Status400BadRequest;
                responseData = new BaseInfo
                {
                    Code = -1,
                    Message = "Refresh Token has expired."
                };
                goto endFunc;
            }

            if (!string.Equals(accessToken, token.AccessToken))
            {
                responseCode = StatusCodes.Status400BadRequest;
                responseData = new BaseInfo
                {
                    Code = -1,
                    Message = "Refresh Token and Access Token do not match."
                };
                goto endFunc;
            }

            //
            var user = JWTHelper.GetUserInfo(accessToken);
            if (user == null || string.IsNullOrEmpty(user.UserName))
            {
                responseCode = StatusCodes.Status400BadRequest;
                responseData = new BaseInfo
                {
                    Code = -1,
                    Message = "User not logged on."
                };
                goto endFunc;
            }

            //
            LoginMem.RemoveRefreshToken(token.RefreshToken);

            var now = DateTime.UtcNow;
            var refresh_token = new IdentityRefreshToken
            {
                Identity = user.UserName,
                RefreshToken = Guid.NewGuid().ToString("N"),
                IssueTimeUtc = DateTime.UtcNow,
                ExpiryTimeUtc = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Utc).AddDays(1),
            };

            var returnValue = await GetJwtAsync(requestId, refresh_token.RefreshToken, user);
            refresh_token.AccessToken = returnValue.Item2;

            LoginMem.SetRefreshToken(refresh_token);

            //LoginMem.UpdateUserLoginState(user.UserName, browserInfo.Ip, false);

            //
            Logger.log.Info($"Time: \"{DateTime.Now:O}\". User refresh token: \"{user.UserName}\". Ip \"{browserInfo.Ip}\"");

            responseCode = StatusCodes.Status200OK;
            responseData = returnValue.Item1;

        //
        endFunc:
            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = new { parameters },
            }));

            return StatusCode(responseCode, responseData);
        }

        private async Task<Tuple<string, string>> GetJwtAsync(string requestId, string refresh_token, MWUser user)
        {
            var now = DateTime.UtcNow;

            //Lấy quyền từ bảng trung gian
            List<MWUserFunction> functionSettingsByUser;
            functionSettingsByUser = user.FunctionSettings;

            LoginMem.SetFunctions(user.UserName, functionSettingsByUser);

            //
            var claims = new Claim[]
            {
                new Claim(CustomClaimTypes.UserName, user.UserName),
                new Claim(ClaimTypes.GivenName, user.Name, ClaimValueTypes.String),
                new Claim(ClaimTypes.NameIdentifier, user.UserName, ClaimValueTypes.String),
            };

            var signingKey = JWTHelper.GetSecretInfo();
            var expires = now.Add(TimeSpan.FromMinutes(20));

            var jwt = new JwtSecurityToken(
                issuer: c_settings.Value.Iss,
                audience: c_settings.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            //
            var loggedUser = LoginMem.GetLoggedUserFromUser(user);

            var response = new
            {
                code = ErrorCodes.Success,
                message = "_",
                jsonData = "",
                //
                access_token = accessToken,
                expiryTime = expires,
                refresh_token,
                fullName = user.Name,
                username = user.UserName,
                avatar = user.Avatar,
                userId = user.UserName,
                loginType = user.LoginType,
                mustChangePassword = loggedUser.MustChangePassword,
                userType = loggedUser.UserType,
                functionSettings = loggedUser.FunctionSettings,
                freelancer = loggedUser.Freelancer,
                client = loggedUser.Client,
                isEkycVerified = user.IsEkycVerified,
                isEmailVerified = user.IsEmailVerified,
            };

            return new Tuple<string, string>(JsonHelper.Serialize(response), accessToken);
        }
        #endregion
    }
}
