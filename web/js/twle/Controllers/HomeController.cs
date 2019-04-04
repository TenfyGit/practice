using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using twle.Models;

namespace twle.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Introduct()
        {
            return View();
        }
        public IActionResult IsNaN()
        {
            return View();
        }
        public IActionResult Output()
        {
            return View();
        }
    }
}
