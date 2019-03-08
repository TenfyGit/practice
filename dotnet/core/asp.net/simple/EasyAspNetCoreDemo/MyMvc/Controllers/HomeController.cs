using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMvc.Models;
using Microsoft.Extensions.Configuration;

namespace MyMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices]IConfiguration configuration)
        {
            Customer customer = configuration.GetSection("customer").Get<Customer>();
            return View(customer);
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
    }
}
