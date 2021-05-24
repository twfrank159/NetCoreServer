﻿using System.Collections.Generic;
using System.Linq;
using L5_Swagger.Models;
using Microsoft.AspNetCore.Mvc;
namespace L5_Swagger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsController : Controller
    {
        private readonly List<Cat> _TestData;

        public CatsController(List<Cat> TestData)
        {
            _TestData = TestData;
            if (_TestData.Count() == 0)
            {
                _TestData.Add(
               new Cat
               {
                   Id = 0,
                   Name = "Umi",
                   Color = "Gary",
                   Cute = true
               });

                _TestData.Add(
                    new Cat
                    {
                        Id = 1,
                        Name = "MiMi",
                        Color = "White",
                        Cute = true
                    });
            }
        }
        [HttpGet()]
        public IActionResult Index()
        {
            return Content("[CatGetAll]/[CatGet/Id]/[CatAdd]/[CatUpdate/Id]/[CatDelete/Id]");
        }

        [HttpGet("CatGetAll")]
        public IActionResult CatGetAll()
        {
            return Json(_TestData);
        }

        [HttpGet("CatGet/{Id}")]
        public IActionResult CatGet(int Id)
        {
            if (_TestData.Exists(d=>d.Id==Id))
            {
                var cat = _TestData.Find(d => d.Id == Id);
                return Json(cat);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("CatAdd")]
        public IActionResult CatAdd(Cat Cat_Add)
        {
            _TestData.Add(Cat_Add);

            object Response = new
            { 
                StatusCode = 200,
                Status = "OK",
                DataCount = _TestData.Count(),
                Data = _TestData
            };

            return Json(Response);
        }

        [HttpPut("CatUpdate/{Id}")]
        public IActionResult CatUpdate(int Id, Cat Cat_New)
        {
            if (_TestData.Exists(d => d.Id == Id))
            {
                var Idx = _TestData.FindIndex(d => d.Id == Id);
                _TestData[Idx] = Cat_New;
                return Json(_TestData);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("CatDelete/{Id}")]
        public IActionResult CatDelete(int Id)
        {
            if (_TestData.Exists(d => d.Id == Id))
            {
                _TestData.RemoveAt(_TestData.FindIndex(d => d.Id == Id));

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
