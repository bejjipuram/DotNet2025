using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo1.Models;
using System.Collections.Generic;
using System.Linq;
namespace WebApplicationDemo1.Controllers
{
    public class DepartmentController:Controller
    {
        public static List<Department> departments = new List<Department>
        {
            new Department{Id=1,Name="CSE"},
            new Department{Id=2,Name="IT"}
        };
        public IActionResult Index()
        {
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department dept)
        {
            if (!ModelState.IsValid)
            {
                return View(dept);
            }
            dept.Id = departments.Any() ? departments.Max(d => d.Id) + 1 : 1; departments.Add(dept);
            TempData["DeptMessage"] = "Deparment Created";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var dept = departments.FirstOrDefault(d => d.Id == id);
            if (dept != null)
            {
                departments.Remove(dept);
            }
            return RedirectToAction("Index");
        }
    }
}
