using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        private const string AUTHSCHEME = "UserSecurity";
        private const string LOGIN_SQL =
           @"SELECT * FROM OPUser 
            WHERE Id = '{0}' 
              AND Password = HASHBYTES('SHA1', '{1}')";

        private const string LASTLOGIN_SQL =
           @"UPDATE OPUser SET LastLogin=GETDATE() 
                        WHERE Id='{0}'";

        private const string ROLE_COL = "Role";
        private const string NAME_COL = "Name";

        private const string REDIRECT_CNTR = "OnlyPython";
        private const string REDIRECT_ACTN = "Index";

        private const string LECLOGIN_VIEW = "LecLogin";
        private const string STUDLOGIN_VIEW = "StudLogin";


        private AppDbContext _dbContext;

        public AccountController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //LECTURER LOGIN
        [AllowAnonymous]
        public IActionResult LecLogin(string returnUrl = null)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View(LECLOGIN_VIEW);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult LecLogin(LecLoginUser user)
        {
            if (!AuthenticateUser(user.Email, user.Password, out ClaimsPrincipal principal))
            {
                ViewData["Message"] = "Incorrect Email or Password";
                ViewData["MsgType"] = "warning";
                return View(LECLOGIN_VIEW);
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

                int num_affected = _dbContext.Database.ExecuteSqlInterpolated($"UPDATE OPUser SET LastLogin=GETDATE() WHERE Email = {user.Email}");

                if (TempData["returnUrl"] != null)
                {
                    string returnUrl = TempData["returnUrl"].ToString();
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                }

                return RedirectToAction(REDIRECT_ACTN, REDIRECT_CNTR);
            }
        }

        //STUDENT LOGIN
        [AllowAnonymous]
        public IActionResult StudLogin(string returnUrl = null)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View(STUDLOGIN_VIEW);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult StudLogin(StudLoginUser user)
        {
            if (!AuthenticateUser(user.Email, user.Password, out ClaimsPrincipal principal))
            {
                ViewData["Message"] = "Incorrect Email or Password";
                ViewData["MsgType"] = "warning";
                return View(STUDLOGIN_VIEW);
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

                int num_affected = _dbContext.Database.ExecuteSqlInterpolated($"UPDATE OPUser SET LastLogin=GETDATE() WHERE Email = {user.Email}");

                if (TempData["returnUrl"] != null)
                {
                    string returnUrl = TempData["returnUrl"].ToString();
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                }

                return RedirectToAction(REDIRECT_ACTN, REDIRECT_CNTR);
            }
        }


        [Authorize]
        public IActionResult Logoff(string returnUrl = null)
        {
            HttpContext.SignOutAsync(AUTHSCHEME);
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction(REDIRECT_ACTN, REDIRECT_CNTR);
        }

        [AllowAnonymous]
        public IActionResult Forbidden()
        {
            return View();
        }

        private bool AuthenticateUser(string email, string pw, out ClaimsPrincipal principal)
        {

            DbSet<Opuser> dbs = _dbContext.Opuser;
            var pw_bytes = System.Text.Encoding.ASCII.GetBytes(pw);

            Opuser appUser = dbs.FromSqlInterpolated($"SELECT * FROM OPUser WHERE Email = {email} AND Password = HASHBYTES('SHA1', {pw_bytes})").FirstOrDefault();

            principal = null;

            if (appUser != null)
            {
                principal =
                   new ClaimsPrincipal(
                      new ClaimsIdentity(
                         new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, appUser.Email),
                        new Claim(ClaimTypes.Name, appUser.Name),
                        new Claim(ClaimTypes.Role, appUser.Role)
                         }, "Basic"
                      )
                   );
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
