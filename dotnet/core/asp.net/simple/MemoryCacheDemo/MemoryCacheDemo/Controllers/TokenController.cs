using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MemoryCacheDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace MemoryCacheDemo.Controllers
{
    public class TokenController : Controller
    {
		private IMemoryCache memoryCache;
        public TokenController(IMemoryCache cache)
        {
            memoryCache = cache;
        }
        /// <summary>
        /// 创建注册依赖
        /// </summary>
        public ActionResult<string> Login()
        {
            var cts = new CancellationTokenSource();
            memoryCache.Set(CacheKeys.DependentCTS,cts);
            memoryCache.Set("test","12345678");
            using(var entry = memoryCache.CreateEntry(CacheKeys.UserSession))
            {
                entry.Value = "_x0123456789";
                entry.RegisterPostEvictionCallback(DependentEvictionCallback,this);
                memoryCache.Set(CacheKeys.UserShareData,"这里是共享的数据",new CancellationChangeToken(cts.Token));
                memoryCache.Set(CacheKeys.UserCart,"这里是购物车",new CancellationChangeToken(cts.Token));
            }
            return "设置依赖完成";
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        public IActionResult GetKeys()
        {
            var userInfo = new
            {
                UserSession = memoryCache.Get<string>(CacheKeys.UserSession),
                UserShareData = memoryCache.Get<string>(CacheKeys.UserShareData),
                UserCart = memoryCache.Get<string>(CacheKeys.UserCart),
                Test = memoryCache.Get<string>("test")
            };
            return new JsonResult(userInfo);
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        public ActionResult<string> LogOut()
        {
            memoryCache.Get<CancellationTokenSource>(CacheKeys.DependentCTS).Cancel();
            var userInfo = new
            {
                UserSession = memoryCache.Get<string>(CacheKeys.UserSession),
                UserShareData = memoryCache.Get<string>(CacheKeys.UserShareData),
                UserCart = memoryCache.Get<string>(CacheKeys.UserCart),
                Test = memoryCache.Get<string>("test")
            };
            return new JsonResult(userInfo);
        }
        private static void DependentEvictionCallback(object key,object value,EvictionReason reason,object state)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Key:{key} 已过期，依赖于该 Key 的所有缓存都将过期而处于不可用状态");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}