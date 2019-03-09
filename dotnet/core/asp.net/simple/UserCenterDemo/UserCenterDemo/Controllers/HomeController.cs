using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserCenterDemo.Models;

namespace UserCenterDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Get(int id)
        {
            int code = 0;
            string userName = string.Empty;
            switch (id)
            {
                case 100:
                    userName = "Ron.liang";
                    break;
                default:
                    userName = "Guest";
                    code = 403;
                    break;
            }

            return new JsonResult(new { code, userName });
        }
    }
}
