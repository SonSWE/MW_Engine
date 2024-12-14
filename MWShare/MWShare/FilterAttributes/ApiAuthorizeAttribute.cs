using MWShare.Authen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Object.Core;
using System.Net;
using System.Text.Json;

namespace MWShare.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ApiAuthorizeAttribute : ActionFilterAttribute
    {
        public bool CheckFunction { get; init; } = true;
        public string Action { get; init; } = string.Empty;

        //
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var functionConfig = GetApiAuthorizeFunctionConfig(context);

            context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationValue);

            string token = authorizationValue.ToString();

            IMWAuthClient _boAuthClient = context.HttpContext.RequestServices.GetRequiredService<IMWAuthClient>();
            Tuple<HttpStatusCode, LoggedUser> verifyResult = await _boAuthClient.ValidateTokenAndFunction(token, functionConfig?.FunctionId ?? string.Empty, Action, CheckFunction);
            if (verifyResult == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (verifyResult.Item1 != HttpStatusCode.OK)
            {
                switch (verifyResult.Item1)
                {
                    case HttpStatusCode.Unauthorized:
                        context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        break;
                    case HttpStatusCode.Forbidden:
                        context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                        break;
                    default:
                        context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                }

                return;
            }

            context.HttpContext.Items["User"] = verifyResult.Item2;

        
            await next();
        }

        private ApiAuthorizeFunctionConfigAttribute? GetApiAuthorizeFunctionConfig(ActionExecutingContext context)
        {
            var attributes = context.Controller.GetType().GetCustomAttributes(typeof(ApiAuthorizeFunctionConfigAttribute), true);

            if (attributes != null && attributes.Length > 0)
            {
                return (ApiAuthorizeFunctionConfigAttribute)attributes[0];
            }

            return null;
        }
    }
}
