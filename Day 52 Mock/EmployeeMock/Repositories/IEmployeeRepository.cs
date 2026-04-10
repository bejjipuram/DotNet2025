using System;
using System.Collections.Generic;
using System.Text;
using EmployeeMock.Models;

namespace EmployeeMock.Repositories
{
    public interface IEmployeeRepository
    {
        Employee? GetById(int id);
        IReadOnlyList<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
