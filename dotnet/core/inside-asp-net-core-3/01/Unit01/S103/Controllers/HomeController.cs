using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S103.Controllers
{
    public class HomeController:Controller
    {
        [Route("/hello")]
        [HttpGet]
        public string SayHello() => "Hello World!";
        [HttpGet("/helloname/{name}")]
        public IActionResult SayHelloName(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
