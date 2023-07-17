using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticalSeventeen.Data.Interfaces;
using PracticalSeventeen.Data.Models;

namespace PracticalSeventeen.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Return dashboard view with all students detail
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Student> students = await _studentRepository.GetAllStudentsAsync();
            return View(students);
        }

        /// <summary>
        /// Return detailed information of single student
        /// </summary>
        /// <param name="id">Student Id</param>
        [HttpGet]
        public async Task<IActionResult> ViewAsync(int id)
        {
            Student student = await _studentRepository.GetStudentByIdAsync(id);
            if (student is null) return NotFound();
            return View(student);
        }

        /// <summary>
        /// Return create student form
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        /// <summary>
        /// Create new student
        /// </summary>
        /// <param name="student">Student object</param>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Student student)
        {
            //future date validation
            if (student.DOB > DateTime.Now)
                ModelState.AddModelError(nameof(Student.DOB), $"Please enter a value less than or equal to {DateTime.Now.ToShortDateString()}.");

            if (!ModelState.IsValid) return View(student);

            int id = await _studentRepository.InsertStudentAsync(student);
            TempData["UserId"] = id;
            return RedirectToAction("Index");
            
        }

        /// <summary>
        /// Return Update student form
        /// </summary>
        /// <param name="id">Student Id</param>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            Student student = await _studentRepository.GetStudentByIdAsync(id);
            if (student is null) return NotFound();
            return View(student);
        }

        /// <summary>
        /// Update student details
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <param name="student">Student object</param>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Student student)
        {
            //future date validation
            if (student.DOB > DateTime.Now)
                ModelState.AddModelError(nameof(Student.DOB), $"Please enter a value less than or equal to {DateTime.Now.ToShortDateString()}.");

            if (!ModelState.IsValid) return View(student);

            bool isUpdated = await _studentRepository.UpdateStudentAsync(id, student);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }

        /// <summary>
        /// Delele student by id
        /// </summary>
        /// <param name="id">Student Id</param>
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
