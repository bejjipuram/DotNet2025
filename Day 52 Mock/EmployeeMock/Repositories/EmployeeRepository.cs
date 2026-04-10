using System;
using System.Collections.Generic;
using EmployeeMock.Models;

namespace EmployeeMock.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", IsActive = true },
            new Employee { Id = 2, Name = "Mike", IsActive = false },
            new Employee { Id = 3, Name = "Sara", IsActive = true }
        };

        public Employee? GetById(int id)
        {
            Console.WriteLine("REAL REPOSITORY: GetById called");

            return _employees.Find(e => e.Id == id);
        }

        public IReadOnlyList<Employee> GetAll()
        {
            Console.WriteLine("REAL REPOSITORY: GetAll called");

            return _employees;
        }

        public void Add(Employee employee)
        {
            Console.WriteLine("REAL REPOSITORY: Add called");

            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            Console.WriteLine("REAL REPOSITORY: Update called");

            var index = _employees.FindIndex(e => e.Id == employee.Id);
            if (index != -1)
            {
                _employees[index] = employee;
            }
        }

        public void Delete(int id)
        {
            Console.WriteLine("REAL REPOSITORY: Delete called");

            var emp = _employees.Find(e => e.Id == id);
            if (emp != null)
            {
                _employees.Remove(emp);
            }
        }
    }
}