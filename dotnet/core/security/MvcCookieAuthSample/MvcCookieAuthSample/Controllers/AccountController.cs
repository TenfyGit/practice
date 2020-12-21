using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MvcCookieAuthSample.Models;

namespace MvcCookieAuthSample.Controllers
{
    public class AccountController : Controller
    {
        private readonly TestUserStore _users;

        public AccountController(TestUserStore users)
        {
            this._users = users;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = returnUrl;
                var user = _users.FindByUsername(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError(nameof(loginViewModel.UserName), "UserName not exists");
                }
                if (_users.ValidateCredentials(loginViewModel.UserName, loginViewModel.Password))
                {
                    var props = new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(30))
                    };
                    IdentityServerUser identityServerUser = new IdentityServerUser(user.SubjectId);
                    identityServerUser.IdentityProvider = user.Username;
                    await Microsoft.AspNetCore.Http.AuthenticationManagerExtensions.SignInAsync(HttpContext, identityServerUser, props);
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(nameof(loginViewModel.Password), "password wrong");
                }
            }
            return View();
        }
    }
}
