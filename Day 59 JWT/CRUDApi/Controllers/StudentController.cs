using Microsoft.AspNetCore.Mvc;

namespace CRUDApi.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
