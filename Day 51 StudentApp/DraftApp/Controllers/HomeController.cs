using DraftApp.Models;
using DraftApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DraftApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public HomeController(StudentPortalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DashboardViewModel vm = new DashboardViewModel();

            vm.TotalStudents = _context.Students.Count();
            vm.TotalCourses = _context.Courses.Count();
            vm.TotalEnrollments = _context.Enrollments.Count();

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
