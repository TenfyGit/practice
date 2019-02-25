using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreIoc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreIoc.Controllers
{
    public class DITestController : Controller
    {
        private readonly ITestService _testService;
        public DITestController(ITestService testService)
        {
            _testService = testService;
        }
        public IActionResult Index()
        {
            ViewBag.date = _testService.GetList("");
            return View();
        }
        public string ReturnString([FromServices]ITestService testService)
        {
            return testService.GetList("").FirstOrDefault();
        }
    }
}