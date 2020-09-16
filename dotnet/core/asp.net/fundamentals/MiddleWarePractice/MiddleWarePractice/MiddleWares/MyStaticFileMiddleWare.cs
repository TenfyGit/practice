using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiddleWarePractice.MiddleWares
{
    public class MyStaticFileMiddleWare
    {
        private readonly RequestDelegate _next;

        public MyStaticFileMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            string path = context.Request.Path.Value;
            if (path.EndsWith(".png"))
            {
                path = path.TrimStart('/');
                return context.Response.SendFileAsync(path);
            }
            return _next(context);
        }
    }
}
