using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace L6_Exception_Log.Filter
{


    
    public class ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }

    /*
        //非同步
        public class SampleAsyncActionFilter : Attribute, IAsyncActionFilter
        {
            public async Task OnActionExecutionAsync(
                ActionExecutingContext context,
                ActionExecutionDelegate next)
            {
                await context.HttpContext.Response.WriteAsync("Async Sample Action in \r\n");

                var resultContext = await next();

                await context.HttpContext.Response.WriteAsync("Async Sample Action out \r\n");
            }
        }
    */

    public class ExceptionFilter : Attribute ,IExceptionFilter
    {
        private readonly ILogger _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this._logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"\n\nThis is my exception [{context.Exception.Message}]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
            //var errorMessage = $"{DateTime.Now.ToLongTimeString()} | {context.Exception}";
            _logger.LogError("\n\n!!!!!!!!!!!!!!!Error TEST!!!!!!!!!!!!!!!!!!!!!\n\n");
        }
    }

}
