using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemoryCacheDemo.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheDemo.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache memoryCache;
        public HomeController(IMemoryCache cache)
        {
            this.memoryCache = cache;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Set()
        {
            MemoryCacheEntryOptions entryOptions = new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.NeverRemove,
                Size = 1
            };
            memoryCache.Set("userId","0001",entryOptions);
            return new string[]{"value1","value2"};
        }
        [HttpGet]
        public ActionResult<string> Get(int id)
        {
            return memoryCache.Get<string>("userId");
        }
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
    }
}
