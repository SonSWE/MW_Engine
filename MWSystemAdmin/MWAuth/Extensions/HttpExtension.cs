using MWAuth.Helpers;
using MWAuth.MemoryData;
using Object.Core;
using System.Security.Claims;
using UAParser;

namespace MWAuth.Extensions
{
    public static class HttpExtension
    {
        public static string GetRequestLanguage(this HttpRequest httpRequest)
        {
            return httpRequest.Headers["ClientLanguage"].FirstOrDefault() ?? "vi";
        }

        public static string GetAuthorizationToken(this HttpRequest httpRequest)
        {
            return (httpRequest.Headers["Authorization"].FirstOrDefault() ?? "").Replace("Bearer ", "");
        }

        public static MWUser GetUserInfo(this HttpRequest httpRequest)
        {
            if (httpRequest.HttpContext.User.Identity == null || !httpRequest.HttpContext.User.Identity.IsAuthenticated)
                return new();

            var claims = ((ClaimsIdentity)httpRequest.HttpContext.User.Identity).Claims;

            //string userName = claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            //return LoginMem.GetSAUser(userName) ?? new();

            var userId = claims.FirstOrDefault(x => x.Type == CustomClaimTypes.UserName)?.Value;

            return LoginMem.GetUser(userId);
        }

        public static string GetUserName(this HttpRequest httpRequest)
        {
            var user = httpRequest.GetUserInfo();
            return user?.UserName ?? string.Empty;
        }

        public static BrowserInfo GetBrowserInfo(this HttpRequest httpRequest)
        {
            var language = httpRequest.GetRequestLanguage();
            var userAgent = httpRequest.Headers["User-Agent"].FirstOrDefault() ?? string.Empty;

            var c = Parser.GetDefault().Parse(userAgent);
            var ip = httpRequest.Headers["X-Forwarded-For"].FirstOrDefault() ?? string.Empty;
            if (string.IsNullOrEmpty(ip))
            {
                ip = httpRequest.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? string.Empty;
            }

            var requestId = httpRequest.Headers["X-Request-Id"].FirstOrDefault() ?? string.Empty;

            return new BrowserInfo
            {
                OSVersion = c.OS.ToString(),
                DeviceInfo = c.Device.ToString(),
                Family = c.UA.Family,
                Major = c.UA.Major,
                Minor = c.UA.Minor,
                Patch = c.UA.Patch,
                Ip = ip,
                Language = language,
                RequestId = requestId,
            };
        }
    }
}
