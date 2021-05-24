using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L2_DI_ServerObjectDI.Model;

namespace L2_DI_ServerObjectDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController : Controller
    {
        private readonly ITestData _transient;
        private readonly ITestData _scoped;
        private readonly ITestData _singleton;
        private readonly TestDataService _service;


        public MyController(ITransientTestData transient,
                           IScopedTestData scoped,
                           ISingletonTestData singleton
                           , TestDataService service)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
            _service = service;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return Content("Hello My Controller");
        }

        [HttpGet("GetTestData")]
        public IActionResult GetTestData()
        {
            string transientInfo = $"[transient] GetTime {this._transient.GetTime()} Get Hash {this._transient.GetHashCode()}\n";
            string ScopedInfo = $"[scoped] GetTime {this._scoped.GetTime()} Get Hash {this._scoped.GetHashCode()}\n";
            string singletonInfo = $"[singleton] GetTime {this._singleton.GetTime()} Get Hash {this._singleton.GetHashCode()}\n";
            string separate = "===================\n";
           
            return Content(transientInfo+ScopedInfo+singletonInfo+ 
                separate
                + _service.GetTestData());
        }

        [HttpGet("UpdateTime")]
        public IActionResult UpdateTime()
        {
            this._scoped.UpdateTime();
            this._transient.UpdateTime();
            this._singleton.UpdateTime();

            return Content("Update Time");
        }
    }
}
