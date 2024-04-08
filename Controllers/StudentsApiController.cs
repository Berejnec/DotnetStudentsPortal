using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotnetStudentsPortal.Data;
using DotnetStudentsPortal.Models.Entities;

namespace DotnetStudentsPortal.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsApiController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsApiController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await dbContext.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}
