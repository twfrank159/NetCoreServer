using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using L6_Exception_Log.Filter;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.IO;

namespace L6_Exception_Log.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExController : Controller
    {
        private readonly ILogger<ExController> _logger;

        public ExController( ILogger<ExController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        [ActionFilter]
        public void Index()
        {
            _logger.LogTrace("Trace Log Example!");
            _logger.LogDebug("Debug Log Example!");
            _logger.LogInformation("Information Log Example!");
            _logger.LogWarning("Warning Log Example!");
            _logger.LogError("Error Log Example!");

            Response.WriteAsync("Exception Test go [ExWithTry] and [Exception] \r\n" +
                "Type of Log : [Trace], [Debug], [Information], [Warning], [Error] \r\n");

        }

        [HttpGet("/ExWithTry")]
        [TypeFilter(typeof(ExceptionFilter))]
        public void ExWithTry()
        {
            try
            {
                throw new Exception("Some error when do some thing\n");
                Response.WriteAsync("try do some thing\n");
            }
            catch (Exception ex)
            {
                Response.WriteAsync($"{GetType().Name} catch exception. Message: {ex.Message}\n");
            }
            finally
            {
                Response.WriteAsync("must do after do something\n");
            }
        }
        
        [HttpGet("/Exception")]
        [TypeFilter(typeof(ExceptionFilter))]
        public IActionResult ExceptionPage()
        {
            throw new Exception("This is unexpected Exception");
        }        

        [Route("/Error")]
        public IActionResult Error() => Problem();
    }
}
