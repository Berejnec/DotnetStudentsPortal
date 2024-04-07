using DotnetStudentsPortal.Data;
using DotnetStudentsPortal.Models;
using DotnetStudentsPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotnetStudentsPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
            };

            await dbContext.Students.AddAsync(student);        
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
