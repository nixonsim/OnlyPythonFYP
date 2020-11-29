using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using OnlyPythonFYP.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlyPythonFYP.Controllers
{
    public class TemplateController : Controller
    {
        private AppDbContext _dbContext;

        public TemplateController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            DbSet<Qntemplate> dbs = _dbContext.Qntemplate;
            List<Qntemplate> model = dbs.ToList();
            return View(model);
        }

        public IActionResult Display(int id)
        {
            DbSet<Qntemplate> dbs = _dbContext.Qntemplate;

            Qntemplate qntemp = dbs.Where(mo => mo.Id == id)
                                 .FirstOrDefault();

            return View(qntemp);
        }
    }
}
