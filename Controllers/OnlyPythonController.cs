using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
// TODO Lesson03 1-1: import namespaces Lesson03.Models and Microsoft.EntityFrameworkCore
// Un-comment the following two lines:
using OnlyPythonFYP.Models;
using Microsoft.EntityFrameworkCore;


namespace OnlyPythonFYP.Controllers
{
    public class OnlyPythonController : Controller
    {
        private AppDbContext _dbContext;

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public OnlyPythonController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult QuestionList()
        {
            DbSet<Qnsbank> dbs = _dbContext.Qnsbank;
            List<Qnsbank> model = dbs.ToList();
            return View(model);
        }

        public IActionResult CreateQuestion()
        {
            var questions = _dbContext.Qntemplate;
            return View();
        }

        [HttpPost]
        public IActionResult CreateQuestion(Qnsbank qnsbank)
        {
            if (ModelState.IsValid)
            {
                DbSet<Qnsbank> dbs = _dbContext.Qnsbank;
                dbs.Add(qnsbank);

                if (_dbContext.SaveChanges() == 1)
                {
                    TempData["Msg"] = "New question added!";
                }
                else
                {
                    TempData["Msg"] = "Failed to update database!";
                }
            }
            else
                TempData["Msg"] = "Invalid information entered";

            return RedirectToAction("QuestionList");
        }

    }
}
