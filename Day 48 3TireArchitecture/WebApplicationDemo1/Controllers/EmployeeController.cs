using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WebApplicationDemo1.Models;

namespace WebApplicationDemo1.Controllers
{
    public class EmployeeController:Controller
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1,Name="Indra",DepartmentId=1,Salary=50000,Phone="9030134599"},
            new Employee{Id=2,Name="Viswa",DepartmentId=2,Salary=70000,Phone="9866414583"}
        };
        private List<Department> GetDepartments()
        {
            return DepartmentController.departments;
        }

        //READ
        public IActionResult Index()
        {
            //ViewBag.Departments=DepartmentController.departments;
            string data = "India,Russia,German,Spain,France";
            IEnumerable<string> items = data.Split(',');
            return View(items);
        }

        //CREATE-GET
        public IActionResult Create()
        {
            var departments = DepartmentController.departments;

            ViewBag.Departments = departments
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                .ToList();

            return View();
        }

        //CREATE-POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = GetDepartments();
                return View(emp);
            }
            emp.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1; employees.Add(emp);
            var deptName = DepartmentController.departments
    .FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name;

            TempData["ActionMessage"] = $"Created -> ID: {emp.Id}, Name: {emp.Name}, Department: {deptName}, Salary: {emp.Salary}, Phone: {emp.Phone}";
            return RedirectToAction("Index");
        }

        //EDIT-GET
        public IActionResult Edit(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            ViewBag.Departments = new SelectList(
                DepartmentController.departments,
                "Id",
                "Name",
                emp.DepartmentId
            );

            return View(emp);
        }

        //EDIT-POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(
                    DepartmentController.departments,
                    "Id",
                    "Name",
                    emp.DepartmentId
                );
                return View(emp);
            }

            var existing = employees.FirstOrDefault(e => e.Id == emp.Id);

            if (existing == null)
            {
                return NotFound(); // prevents crash
            }

            existing.Name = emp.Name;
            existing.DepartmentId = emp.DepartmentId;
            existing.Salary = emp.Salary;
            existing.Phone = emp.Phone;

            var deptName = DepartmentController.departments
                .FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name;

            TempData["ActionMessage"] =
                $"Updated -> ID: {emp.Id}, Name: {emp.Name}, Department: {deptName}, Salary: {emp.Salary}, Phone: {emp.Phone}";

            return RedirectToAction("Index");
        }

        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                var deptName = DepartmentController.departments
                    .FirstOrDefault(d => d.Id == emp.DepartmentId)?.Name;

                TempData["ActionMessage"] =
                    $"Deleted -> ID: {emp.Id}, Name: {emp.Name}, Department: {deptName}, Salary: {emp.Salary}, Phone: {emp.Phone}"; employees.Remove(emp);
            }
            return RedirectToAction("Index");
        }
        
    }
}
