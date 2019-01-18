using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using sample.Models;
using System.Threading.Tasks;
using System.Net;

namespace sample.Extentions.Middlewares
{
    public class RequestSetOptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private IOptions<AppOptions> _injectedOptions;
        public RequestSetOptionsMiddleware(RequestDelegate next,IOptions<AppOptions> injectedOptions)
        {
            _next = next;
            _injectedOptions = injectedOptions;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("RequestSetOptionsMiddleware.Invoke");
            var option = httpContext.Request.Query["option"];
            if(!string.IsNullOrWhiteSpace(option))
            {
                _injectedOptions.Value.Option = WebUtility.HtmlEncode(option);
            }
            await _next(httpContext);
        }
    }
}
