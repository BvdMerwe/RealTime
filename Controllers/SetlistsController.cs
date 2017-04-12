using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealTime.Data;
using RealTime.Models.ViewModels;

namespace RealTime.Controllers
{
    [Authorize]
    public class SetlistsController : Controller {
        private ApplicationDbContext _dbContext;

        public SetlistsController(ApplicationDbContext context) {
            _dbContext = context;
        }
        public IActionResult Index() {
            // var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // optionsBuilder.UseSqlite("Data Source=./RealTime.db");
            // using (var _dbContext = new ApplicationDbContext(optionsBuilder.Options)) {
                var model = new SetlistsViewModel (){
                    Setlists = _dbContext.Setlists.Include(s => s.Questions).ThenInclude(q => q.Answers).ToList()
                };
                return View(model);
            // }
        }

        public IActionResult Add() {
            ViewBag.Types = _dbContext.QuestionTypes.Select(i => new SelectListItem()
                                                        {
                                                            Text = i.Type, 
                                                            Value = i.Id.ToString()
                                                        });
            var model = new AddSetlistViewModel(){};
            model.Questions = new List<QuestionViewModel>(){
                new QuestionViewModel(){
                    Answers = {
                        new AnswerViewModel()
                    }
                }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddSetlistViewModel model) {
            ViewBag.Types = _dbContext.QuestionTypes.Select(i => new SelectListItem()
                                                        {
                                                            Text = i.Type, 
                                                            Value = i.Id.ToString()
                                                        });
            return View(model);
        }
    }
}