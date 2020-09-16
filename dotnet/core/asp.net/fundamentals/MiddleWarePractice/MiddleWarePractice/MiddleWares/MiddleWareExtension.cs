using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace MiddleWarePractice.MiddleWares
{
    public static class MiddleWareExtension
    {
        public static IApplicationBuilder UseMyStaticFile(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            return app.UseMiddleware<MyStaticFileMiddleWare>();
        }
    }
}
