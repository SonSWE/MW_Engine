using MWAuth.MemoryData;
using CommonLib;
using Microsoft.IdentityModel.Tokens;
using Object.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MWAuth.Helpers
{
    public static class JWTHelper
    {
        public static MWUser? ValidateTokenAndGetUserInfo(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                    return null;

                var audienceConfig = ConfigDataAuth.Audience;
                var tokenHandler = new JwtSecurityTokenHandler();
                var signingKey = GetSecretInfo();

                if (tokenHandler.CanReadToken(token))
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        // The signing key must match!
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,

                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = audienceConfig["Iss"],

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = audienceConfig["Aud"],

                        // Validate the token expiry
                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;

                    var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.UserName)?.Value;

                    return LoginMem.GetUser(userId);
                }
            }
            catch
            {
            }

            return default;
        }

        public static MWUser? GetUserInfo(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            var audienceConfig = ConfigDataAuth.Audience;
            var tokenHandler = new JwtSecurityTokenHandler();
            var signingKey = GetSecretInfo();

            if (tokenHandler.CanReadToken(token))
            {
                var tokenRead = tokenHandler.ReadJwtToken(token);

                var userId = tokenRead.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.UserName)?.Value;

                return LoginMem.GetUser(userId);
            }

            return null;
        }

        public static SymmetricSecurityKey GetSecretInfo()
        {
            var audienceConfig = ConfigDataAuth.Audience;
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            //var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            //var signingKey = new SymmetricSecurityKey(keyByteArray);
            //return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(symmetricKeyAsBase64.PadRight((512 / 8), '\0')));
            //return signingKey;

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
        }

        public static string GetAccessToken(Claim[] claims)
        {
            var now = DateTime.UtcNow;
            var signingKey = GetSecretInfo();
            var expires = now.Add(TimeSpan.FromMinutes(20));

            var jwt = new JwtSecurityToken(
                issuer: ConfigDataAuth.Audience["Iss"],
                audience: ConfigDataAuth.Audience["Aud"],
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return accessToken;
        }
    }
}
