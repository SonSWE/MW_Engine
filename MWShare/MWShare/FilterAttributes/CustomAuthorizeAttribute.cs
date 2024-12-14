using MWShare.Authen;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Object.Core;
using System.Net;

public class CustomAuthorizeAttribute : TypeFilterAttribute
{
    public CustomAuthorizeAttribute(string Action, string FunctionID, bool CheckFunction) : base(typeof(CustomAuthorizeFilter))
    {
        Arguments = new object[] { Action, FunctionID, CheckFunction };
    }
}

public class CustomAuthorizeFilter : IAuthorizationFilter
{
    private readonly IMWAuthClient _boAuthClient;
    protected string Action { get; set; }
    protected string FunctionId { get; set; }
    protected bool CheckFunction { get; set; } = true;


    public CustomAuthorizeFilter(IMWAuthClient boAuthClient, string Action, string FunctionID, bool CheckFunction)
    {
        _boAuthClient = boAuthClient;
        this.Action = Action;
        this.FunctionId = FunctionID;
        this.CheckFunction = CheckFunction;
    }
    /// <summary>
    /// Hảm authorization 
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="RpcException"></exception>
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Context = null thì loại luôn request
        if (context == null || context.HttpContext == null)
        {
            return;
        }

        // Lấy ra chuỗi token tại Header 
        var authorizationHeader = context.HttpContext?.Request?.Headers["Authorization"] ?? string.Empty;

        Tuple<HttpStatusCode, LoggedUser> verifyResult = null;

        if (string.IsNullOrEmpty(authorizationHeader))
        {
            context.Result = new UnauthorizedResult();
            return;
        }


        verifyResult = _boAuthClient.ValidateTokenAndFunction(authorizationHeader, FunctionId, Action, true).Result;

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
                    context.Result = new UnauthorizedResult();
                    break;
                case HttpStatusCode.Forbidden:
                    context.Result = new ForbidResult();
                    break;
                default:
                    context.Result = new BadRequestResult();
                    break;
            }
            return;
        }

        if (context.HttpContext == null) return;

        context.HttpContext.Items["User"] = verifyResult.Item2;
    }
}
