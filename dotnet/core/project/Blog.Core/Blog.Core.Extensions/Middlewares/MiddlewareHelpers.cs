using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Extensions.Middlewares
{
    /// <summary>
    /// 这里定义一个中间件Helper，主要作用就是给当前模块的中间件取一个别名
    /// </summary>
    public static class MiddlewareHelpers
    {
        public static IApplicationBuilder UseJwtTokenAuth(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JwtTokenAuth>();
        }
    }
}
