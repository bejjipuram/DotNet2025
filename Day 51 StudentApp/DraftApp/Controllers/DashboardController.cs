using DraftApp.Models;
using DraftApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DraftApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public DashboardController(StudentPortalDbContext context)
        {
            _context = context;
        }

        public IActionResult ViewModelDashboard()
        {
            DashboardViewModel vm = new DashboardViewModel();

            vm.Students = _context.Students.ToList();
            vm.Courses = _context.Courses.ToList();
            vm.Enrollments = _context.Enrollments.ToList();

            vm.TotalStudents = vm.Students.Count;
            vm.TotalCourses = vm.Courses.Count;
            vm.TotalEnrollments = vm.Enrollments.Count;

            return View(vm);
        }
    }
}