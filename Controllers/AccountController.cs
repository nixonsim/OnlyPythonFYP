using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Security.Claims;
using OnlyPythonFYP.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;

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

        [AllowAnonymous]
        [HttpPost]
        public IActionResult StudLogin(StudLoginUser user)
        {
            if (!AuthenticateUser(user.Email, user.Password, out ClaimsPrincipal principal))
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

            DbSet<Opuser> dbs = _dbContext.Opuser;
            var pw_bytes = System.Text.Encoding.ASCII.GetBytes(pw);

            Opuser appUser = dbs.FromSqlInterpolated($"SELECT * FROM OPUser WHERE Email = {email} AND Password = HASHBYTES('SHA1', {pw_bytes})").FirstOrDefault();

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

        public IActionResult CheckIfStud(string email)
        {
            Regex rx = new Regex(@"180\d{5}@myrp.edu.sg", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(email);
            if (matches.Count < 0)
            {
                return Json($"You are not a student! Return back to main page.");
            }
            return Json(true);
        }

    }
}