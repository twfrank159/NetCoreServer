using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace L8_SignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Client")]
        public IActionResult Client()
        {
            return View();
        }

    }
}
