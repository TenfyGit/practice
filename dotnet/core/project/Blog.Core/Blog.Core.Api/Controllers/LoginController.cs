using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.Extensions.Authorizations.Helpers;
using Blog.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 获取JWT的方法1
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public async Task<MessageModel<string>> GetJwtStr(string name, string pass)
        {
            string jwtStr = string.Empty;
            bool suc = false;
            // 获取用户的角色名，请暂时忽略其内部是如何获取的，可以直接用 var userRole="Admin"; 来代替更好理解。
            var userRole = "Admin";
            if (userRole != null)
            {
                //将用户id和角色名，作为单独的自定义变量封装进token字符串中
                TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = userRole };
                jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }
            return new MessageModel<string>()
            {
                success = suc,
                msg = suc ? "获取成功" : "获取失败",
                response = jwtStr
            };
        }
    }
}
