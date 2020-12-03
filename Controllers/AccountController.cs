using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyPythonFYP.Models;

namespace OnlyPythonFYP.Controllers
{
    public class AccountController : Controller
    {
        private const string AUTHSCHEME = "UserSecurity";
        private const string LOGIN_SQL =
           @"SELECT * FROM StdUser 
            WHERE Email = '{0}' 
              AND Password = HASHBYTES('SHA1', '{1}')";

        private const string NAME_COL = "Name";

        private const string LOGIN_VIEW = "Login";

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View(LOGIN_VIEW);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            if (!AuthenticateUser(user.Email, user.Password, out ClaimsPrincipal principal))
            {
                ViewData["Message"] = "Incorrect email or Password";
                ViewData["MsgType"] = "warning";
                return View(LOGIN_VIEW);
            }
            else
            {
                HttpContext.SignInAsync(
                   AUTHSCHEME,
                   principal,
               new AuthenticationProperties
               {
                   IsPersistent = false
               });

                if (TempData["returnUrl"] != null)
                {
                    string returnUrl = TempData["returnUrl"].ToString();
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "OnlyPython");
            }
        }


        public IActionResult Logoff(string returnUrl = null)
        {
            HttpContext.SignOutAsync(AUTHSCHEME);
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction();
        }

        [AllowAnonymous]
        public IActionResult Forbidden()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult StudLogin()
        {
            return View();
        }

        private bool AuthenticateUser(string email, string pw,
                                      out ClaimsPrincipal principal)
        {
            principal = null;


            DataTable ds = DBUtl.GetTable(LOGIN_SQL, email, pw);
            if (ds.Rows.Count == 1)
            {
                principal =
                   new ClaimsPrincipal(
                      new ClaimsIdentity(
                         new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, ds.Rows[0]["Id"].ToString()),
                        new Claim(ClaimTypes.Name, ds.Rows[0][NAME_COL].ToString()) }
                      )
                   );
                return true;
            }
            return false;
        }
    }
}