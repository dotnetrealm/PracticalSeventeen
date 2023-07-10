using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticalSeventeen.Data.Interfaces;
using PracticalSeventeen.Data.Models;

namespace PracticalSeventeen.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Student> students = await _studentRepository.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> ViewAsync(int id)
        {
            Student student = await _studentRepository.GetStudentByIdAsync(id);
            if (student is null) return NotFound();
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Student student)
        {
            //future date validation
            if (student.DOB > DateTime.Now)
                ModelState.AddModelError(nameof(Student.DOB), $"Please enter a value less than or equal to {DateTime.Now.ToShortDateString()}.");

            if (ModelState.IsValid)
            {
                int id = await _studentRepository.InsertStudentAsync(student);
                TempData["UserId"] = id;
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            Student student = await _studentRepository.GetStudentByIdAsync(id);
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, Student student)
        {
            bool isUpdated = await _studentRepository.UpdateStudentAsync(id, student);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool isDeleted = await _studentRepository.DeleteStudentAsync(id);
            if (isDeleted) return RedirectToAction("Index");
            return RedirectToAction("Error", "Home");
        }
    }
}
