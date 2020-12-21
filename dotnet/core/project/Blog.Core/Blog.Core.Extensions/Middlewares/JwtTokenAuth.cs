using Blog.Core.Extensions.Authorizations.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Extensions.Middlewares
{
    public class JwtTokenAuth
    {
        private readonly RequestDelegate _next;

        public JwtTokenAuth(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            //检测是否包含Authorization请求头
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                return _next(httpContext);
            }
            var tokenHeader = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ","");
            try
            {
                if (tokenHeader.Length >= 128)
                {
                    TokenModelJwt tm = JwtHelper.SerializeJwt(tokenHeader);
                    //授权Claim
                    var claimList = new List<Claim>();
                    var claim = new Claim(ClaimTypes.Role, tm.Role);
                    claimList.Add(claim);
                    var identity = new ClaimsIdentity(claimList);
                    var principal = new ClaimsPrincipal(identity);
                    httpContext.User = principal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} middleware wrong:{ex.Message}");
            }
            return _next(httpContext);
        }
    }
}
