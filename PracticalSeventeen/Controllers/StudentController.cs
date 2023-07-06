using Microsoft.AspNetCore.Mvc;
using PracticalSeventeen.Data.Interfaces;
using PracticalSeventeen.Data.Models;

namespace PracticalSeventeen.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Student> students = await _studentRepository.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Student student)
        {
            if (ModelState.IsValid)
            {
                int id = await _studentRepository.InsertStudentAsync(student);
                TempData["UserId"] = id;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Student student = await _studentRepository.GetStudentByIdAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            bool isUpdated = await _studentRepository.UpdateStudentAsync(id, student);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _studentRepository.DeleteStudentAsync(id);
            if (isDeleted) return RedirectToAction("Index");
            return RedirectToAction("Error", "Home");
        }
    }
}
