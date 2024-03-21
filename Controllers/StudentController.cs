using First_Web_Application.Data;
using First_Web_Application.Models;
using First_Web_Application.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_Web_Application.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext dBContext;
        public StudentController(ApplicationDBContext dbContext)
        {
            this.dBContext = dbContext;
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
                IsActive = viewModel.IsActive,
            };
            await dBContext.Students.AddAsync(student);
            await dBContext.SaveChangesAsync();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dBContext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student=await dBContext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dBContext.Students.FindAsync(viewModel.ID);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;    
                student.IsActive = viewModel.IsActive;
                await dBContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
            
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel )
        {
            var student = await dBContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.ID==viewModel.ID);
            if (student is not null)
            {
                dBContext.Students.Remove(viewModel);
                await dBContext.SaveChangesAsync();

            }
            return RedirectToAction("List","Student");
        }
        }

    }
    
