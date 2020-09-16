using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApiAuthorization.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        #region 用户登陆
        [AllowAnonymousAttribute]
        [HttpGet]
        public string Login(string account, string password)
        {
            if ("Admin".Equals(account) && "123456".Equals(password))//应该数据库校验
            {
                FormsAuthenticationTicket ticketObject = new FormsAuthenticationTicket(0, account, DateTime.Now, DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", account, password), FormsAuthentication.FormsCookiePath);
                var result = new
                {
                    Result = true,
                    Ticket = FormsAuthentication.Encrypt(ticketObject)
                };
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = new { Result = false };
                return JsonConvert.SerializeObject(result);
            }
        }
        #endregion
    }
}
