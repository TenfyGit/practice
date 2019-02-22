using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using WebApiCORS.Models;

namespace WebApiCORS.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// 用戶登錄
        /// </summary>
        /// <param name="strUser"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        [HttpGet]
        public object Login(string strUser, string strPwd)
        {
            if (!ValidateUser(strUser, strPwd))
            {
                return new { bRes = false };
            }
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, strUser, DateTime.Now, DateTime.Now.AddHours(1), 
                true, string.Format("{0}&{1}", strUser, strPwd), FormsAuthentication.FormsCookiePath);
            //返回登錄結果,用戶信息,用戶驗證票據信息
            var oUser = new UserInfo { bRes = true,UserName = strUser,Password = strPwd,Ticket = FormsAuthentication.Encrypt(ticket)};
            //將身份信息保存在session中,驗證當前請求是否有效請求
            HttpContext.Current.Session[strUser] = oUser;
            return oUser;
        }
        /// <summary>
        /// 校驗用戶名密碼
        /// </summary>
        /// <param name="strUser"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        private bool ValidateUser(string strUser, string strPwd)
        {
            if (strUser == "admin" && strPwd == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}