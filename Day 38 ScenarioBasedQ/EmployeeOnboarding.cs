using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_38_ScenarioBasedQ
{
    public class EmployeeOnboarding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public EmployeeOnboarding(int id,string name,string email, double salary)
        {
            Id = id;
            Name = name;
            if (salary <= 0)
            {
                Salary = 30000;
            }
            else
            {
                {
                    Salary = salary;
                }
            }

            if (!email.Contains('@'))
            {
                Email = "unknown@company.com";
            }
            else
            {
                Email = email;
            }
        }

    }
    public class EmployeeOnboardingMain
    {
        public static void Main(string[] args)
        {
            EmployeeOnboarding emp = new EmployeeOnboarding(1, "Rayappa", "Email.companny.com", 50000);
            EmployeeOnboarding emp1 = new EmployeeOnboarding(2, "Salaria", "Email@company.com", 0);
            EmployeeOnboarding emp2 = new EmployeeOnboarding(3, "Krishna", "krishna@company.com", 70000);

            Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Email: {emp.Email}, Salary: {emp.Salary}\n");
            Console.WriteLine($"Id: {emp1.Id}, Name: {emp1.Name}, Email: {emp1.Email}, Salary: {emp1.Salary}\n");
            Console.WriteLine($"Id: {emp2.Id}, Name: {emp2.Name}, Email: {emp2.Email}, Salary: {emp2.Salary}\n");
        }
    }
}
