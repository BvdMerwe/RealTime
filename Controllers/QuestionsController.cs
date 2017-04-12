using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealTime.Data;
using RealTime.Models;
using RealTime.Models.ViewModels;

namespace RealTime.Controllers {
    public class QuestionsController : Controller {
        private ApplicationDbContext _dbContext;

        public QuestionsController(ApplicationDbContext context) {
            _dbContext = context;
        }
        public IActionResult Index() {
            // var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // optionsBuilder.UseSqlite("Data Source=./RealTime.db");
            // using (var _dbContext = new ApplicationDbContext(optionsBuilder.Options)) {
                var model = new QuestionsViewModel(){
                    Questions = _dbContext.Questions.Include(q => q.Answers).ToList()
                };
                return View(model);
            // }
        }
    }
}