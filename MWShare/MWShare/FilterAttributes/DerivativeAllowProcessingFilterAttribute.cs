using Azure.Core;
using MWShare.Helpers;
using CommonLib;
using CommonLib.Constants;
using CommonLib.Extensions;
using MemoryData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MWShare.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class DerivativeAllowProcessingFilterAttribute : ActionFilterAttribute, IOrderedFilter
    {
        public new int Order { get; set; } = 1;


        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (context.HttpContext.Items.ContainsKey("ExcludedDerivativeCheck") && (bool?)context.HttpContext.Items["ExcludedDerivativeCheck"] == true)
            {
                goto endFunc;
            }
            var derivativeFunctionConfig = GetTransactionBaseControllerDerivativeFunctionAttribute(context);

            if (derivativeFunctionConfig?.ExcludedMethods.Length > 0 && derivativeFunctionConfig?.ExcludedMethods.Contains(actionDescriptor?.ActionName) == true)
            {
                goto endFunc;
            }

        endFunc:
            await next();
        }

        private DerivativeFunctionConfigAttribute? GetTransactionBaseControllerDerivativeFunctionAttribute(ActionExecutingContext context)
        {
            var attributes = context.Controller.GetType().GetCustomAttributes(typeof(DerivativeFunctionConfigAttribute), true);
            if (attributes != null && attributes.Length > 0)
            {
                return (DerivativeFunctionConfigAttribute)attributes[0];
            }

            return null;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class DerivativeFunctionConfigAttribute : Attribute
    {
        public string[] ExcludedMethods { get; init; } = Array.Empty<string>();
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExcludeDerivativeCheckAttribute : ActionFilterAttribute, IOrderedFilter
    {
        public new int Order { get; set; } = 0;
        public bool IsExcluded { get; init; } = true;
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["ExcludedDerivativeCheck"] = true;
        }
    }

}
