using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlyPython.Models;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;

namespace OnlyPython.Controllers
{
    public class ExercisesController : Controller
    {
        private AppDbContext _dbContext;

        public ExercisesController(AppDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            DbSet<Qnsbank> dbs = _dbContext.Qnsbank;
            List<Qnsbank> model = dbs.ToList();
            return View(model);
        }
        public IActionResult CreateExercise()
        {
        DbSet<ExerPaper> dbs = _dbContext.ExerPaper;
        var lstExerPaper = dbs.ToList();
        ViewData["Experpapers"] = new SelectList(lstExerPaper, "Id", "ExerName");
        return View();
        }
        [HttpPost]
        public IActionResult CreateExercise(ExerPaper ExerPaperInfo)
        {
            if (ModelState.IsValid)
            {
                DbSet<ExerPaper> dbs = _dbContext.ExerPaper;
                dbs.Add(ExerPaperInfo);
                if (_dbContext.SaveChanges() == 1)
                    TempData["Msg"] = "New Exercise Paper added successfully!";
                else
                    TempData["Msg"] = "Failed to create Exercise Paper";
            }
            else
            {
                TempData["Msg"] = "Invalid information Entered";
            }
            return RedirectToAction("Index"); //idk whats the home page called
        }
    }
}
