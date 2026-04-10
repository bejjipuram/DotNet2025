using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationDemo1.Models;

namespace WebApplicationDemo1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("../Employees/AddEmployee");
        }
        public IActionResult Squaring()
        {
            int number = 5 * 5;
            return Content(number.ToString());
        }
        public IActionResult Divisible()
        {
            int x = 10;
            int y = 0;
            int result = x / y;
            return Content(result.ToString());
        }
        public IActionResult Error1()
        {
            return View();
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
