using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_16
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public Employee()
        {
        }

    }
    public class ProgramMain
    {
        public static void Main(string[] args)
        {
            Employee emp = new Employee
            {
                Id=12204083,
                Name="Indra",
                Salary=1500000,
            };
            Console.WriteLine(emp.Name);
        }
    }
}
