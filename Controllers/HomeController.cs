using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyPythonFYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyPythonFYP.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult LecLogin()
        {
            return RedirectToAction("LecLogin", "Account");
        }

        [AllowAnonymous]
        public IActionResult StudLogin()
        {
            return RedirectToAction("StudLogin", "Account");
        }
    }
}
