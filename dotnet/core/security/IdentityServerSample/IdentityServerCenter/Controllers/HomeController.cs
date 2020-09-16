using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Test;
using IdentityServerCenter.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerCenter.Controllers
{
    public class HomeController : Controller
    {
        private TestUserStore _testUserStore;

        public HomeController(TestUserStore testUserStore)
        {
            _testUserStore = testUserStore;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ViewBag.returnUrl = returnUrl;
                var user = _testUserStore.FindByUsername(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError(nameof(user.Username),"用户名不存在");
                }
                else
                {
                    bool result = _testUserStore.ValidateCredentials(loginViewModel.UserName, loginViewModel.Password);
                    if (result)
                    {
                        var props = new AuthenticationProperties()
                            {
                                IsPersistent = true,
                                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                            };
                        await HttpContext.SignInAsync(user.SubjectId, user.Username, props);
                        return RedirectToRoute(returnUrl);
                    }
                    ModelState.AddModelError(nameof(user.Password),"密码错误");
                }
            }
            return View();
        }
    }
}