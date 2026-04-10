using System;
using System.Collections.Generic;
using System.Text;
using EmployeeMock.Models;
using EmployeeMock.Repositories;

namespace EmployeeMock.Services
{
    public sealed class EmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo) { _repo = repo; }
        public Employee GetEmployeeOrThrow(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException("Id must be greater than zero.", nameof(id));
            var employee = _repo.GetById(id);
            if (employee is null) throw new KeyNotFoundException($"Employee with id {id} not found");
            return employee;
        }
    }
}
