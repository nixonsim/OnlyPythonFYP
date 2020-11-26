using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OnlyPythonFYP.Models;

namespace OnlyPythonFYP.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Logoff(string returnUrl = null)
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Login");
        }


        public IActionResult Login(string returnUrl = null)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            if (!AuthenticateUser(user.Email, user.Password,
                                  out ClaimsPrincipal principal))
            {
                ViewData["Message"] = "Incorrect Email or Password";
                return View("Login");
            }
            else
            {
                HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   principal);

                if (TempData["returnUrl"] != null)
                {
                    string returnUrl = TempData["returnUrl"].ToString();
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                }

                return RedirectToAction("Index");
            }
        }

        private bool AuthenticateUser(string uid, string pw,
                                      out ClaimsPrincipal principal)
        {
            principal = null;

            // TODO L08 Task 1 - Provide Login SELECT Statement
            string sql = @"Select * from SRUser
                        where Email='{0}' and 
                        Password = HASHBYTES('SHA1','{1}')";

            string select = String.Format(sql, uid, pw);
            DataTable ds = DBUtl.GetTable(select);
            if (ds.Rows.Count == 1)
            {
                principal =
                   new ClaimsPrincipal(
                      new ClaimsIdentity(
                         new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, uid),
                        new Claim(ClaimTypes.Name, ds.Rows[0]["Email"].ToString())
                         },
                         CookieAuthenticationDefaults.AuthenticationScheme));
                return true;
            }
            return false;
        }
    }
}
