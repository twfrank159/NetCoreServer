using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L3_DBEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace L3_DBEntityFramework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsController : Controller
    {
        private readonly CatsContext _db;

        public CatsController( CatsContext dbContext)
        {
            _db = dbContext;
        }
        [HttpGet()]
        public IActionResult Index()
        {
            return Content($"Meow~ Meow~ Meow~\n" +
                "[ShowMeow]/[AddMeowMeow]/[FuckOutMeow]/[GetMeowById/{Id}]");
        }

        [HttpGet("ShowMeow")]
        public IActionResult ShowMeow()
        {
            int Num = _db.Cats.Count();
            List<string> Name_List = _db.Cats.Select(c => c.Name).ToList();

            return Content($"Num of Meow {Num}\n" + string.Join(',', Name_List));
        }

        [HttpPost("AddMeowMeow")]
        public IActionResult AddMeowMeow(Cat newCat)
        {
            if (!_db.Cats.Any(e => e.Id == newCat.Id))
            {
                _db.Cats.Add(newCat);
                _db.SaveChanges();
            }

            return Ok();
        }

        [HttpGet("FuckOutMeow/{DName}")]
        public IActionResult FuckOutMeow(string? DName)
        {
            var Meow = _db.Cats.Where(c => c.Name == DName).Select(d => d).FirstOrDefault();
            if (Meow != null)
            {
                _db.Cats.Remove(Meow);
                _db.SaveChanges();

                return Content("FuckOut MeowMeow");
            }
            else
            {
                return Content("No MeowMeow QQ");
            }
        }

        [HttpGet("GetMeowById/{Id:int?}")]
        public IActionResult GetMeowById(int Id = 1)
        {
            //var Meow = _db.Cats.FirstOrDefault( c => c.Id == Id );
            var Meow = _db.Cats
                .FromSqlInterpolated($"SELECT * FROM Cats WHERE id = {Id}");

            return Json(Meow);
        }
    }
}
