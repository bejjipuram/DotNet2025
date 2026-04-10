using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Controllers
{
    public class SomeController : Controller
    {
        public IActionResult Index()
        {
            CombinedModel combinedModel = new CombinedModel();
            return View(combinedModel);
        }
    }
}
