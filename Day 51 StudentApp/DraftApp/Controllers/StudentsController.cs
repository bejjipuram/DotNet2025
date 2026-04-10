using DraftApp.Models;
using DraftApp.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace DraftApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string? q)
        {
            var students = await _service.SearchAsync(q);
            return View(students);

        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _service.GetAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            var result = await _service.CreateAsync(student);

            if (!result.ok)
            {
                ModelState.AddModelError("", result.message);
                return View(student);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _service.GetAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentId)
                return NotFound();

            var result = await _service.UpdateAsync(student);

            if (!result.ok)
            {
                ModelState.AddModelError("", result.message);
                return View(student);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch(InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? q)
        {
            var students = await _service.SearchAsync(q);

            return Json(students.Select(s => new {
                studentId = s.StudentId,
                fullName = s.FullName,
                email = s.MaskedEmail,
                status = s.Status
            }));
        }
    }
}