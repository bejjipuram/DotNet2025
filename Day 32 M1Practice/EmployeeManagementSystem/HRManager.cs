//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CAP2025.Day_32_M1Practice.EmployeeManagementSystem
//{
//    public class HRManager
//    {
//        private List<Employee> employees = new List<Employee>();
//        private int autoId = 1;
//        public void AddEmployee(string name,string dept,double salary)
//        {
//            Employee emp = new Employee
//            {
//                EmployeeId = "E" + autoId.ToString("D3"),
//                Name = name,
//                Department=dept,
//                Salary=salary,
//                JoiningDate=DateTime.Now

//            };
//            autoId++;
//            employees.Add(emp);
//        }
//        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
//        {

//        }
//        public double CalculateDepartmentSalary(string department)
//        {

//        }
//        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
//        {

//        }
//    }
//}
