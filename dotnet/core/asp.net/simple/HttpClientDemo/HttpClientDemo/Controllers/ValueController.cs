using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientDemo.Controllers
{
    public class ValueController : Controller
    {
		private WeatherService  weatherService;
        public ValueController(WeatherService service)
        {
            weatherService = service;
        }
        public async Task<ActionResult> GetAction()
        {
            string result = string.Empty;
            try
            {
                result = await weatherService.GetData();
            }
            catch(Exception ex){}
            return new JsonResult(new{result});
        }
    }
}