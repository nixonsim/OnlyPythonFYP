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

            Qntemplate qntemp = dbs.Where(mo => mo.Template_Id == id)
                                 .FirstOrDefault();

            return View(qntemp);
        }

        public IActionResult RunCode()
        {
            {
                var newTopic = ("Lists"); //Type ur Topic here

                // Code for generating Questions
                Random rnd = new Random();
                var x = rnd.Next(0, 5);
                var newbigCities = new List<string>() {

                 "New York",
                 "London",
                 "Mumbai",
                 "Chicago",
                 "Singapore",
                 "Johor Bahru"
                };

                var newQuestion = ("bigCities = [\"New York\", \"London\", \"Mumbai\", \"Chicago\",  \"Singapore\", \"Johor bahru\"]\n\n" +
                    "What is the position of " + newbigCities[x] + " in the BigCities List?");

                var newQuestion_Type = 1; //Question_Type: MCQ - "1"  Open-Ended - "2"
                var newAnswer = x.ToString();

                Random r = new Random();
                List<int> badanswers = new List<int>();
                int y = r.Next(1, 5);

                badanswers.Add(r.Next(1, 5));
                badanswers.Add(r.Next(1, 5));
                badanswers.Add(r.Next(1, 5));


                while (y == badanswers[0] || y == badanswers[1] || y == badanswers[2] || badanswers[0] == badanswers[1] || badanswers[0] == badanswers[2] || badanswers[1] == badanswers[2])
                {
                    badanswers[0] = r.Next(1, 5);
                    badanswers[1] = r.Next(1, 5);
                    badanswers[2] = r.Next(1, 5);
                }
                string NewWrong_Answer = badanswers[0] + "," + badanswers[1] + "," + badanswers[2];

                //Insert into Database
                DbSet<Qntemplate> QNTemplate = _dbContext.Qntemplate;

                List<Qntemplate> QNTemplatelist = QNTemplate.ToList();
                int idCounter = QNTemplatelist.Count() + 1;

                Qnsbank qB = new Qnsbank();
                qB.Topic = newTopic;
                qB.Question = newQuestion;
                qB.Question_Type = newQuestion_Type;
                qB.Answer = newAnswer;
                qB.Wrong_Answer = NewWrong_Answer;
                qB.Template_Id = idCounter;

                _dbContext.Qnsbank.Add(qB);
                _dbContext.SaveChanges();
            }

            return RedirectToAction();
        }

        public IActionResult Temp()
        {
            DbSet<Qntemplate> dbs = _dbContext.Qntemplate;

            Qntemplate qntemp = dbs.Where(mo => mo.Template_Id == 1)
                                 .FirstOrDefault();

            

            return View(qntemp);
        }
    }
}

