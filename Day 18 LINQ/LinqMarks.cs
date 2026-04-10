using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_18
{
    public class Student
    {
        public string Name { get; set; }
        public int Marks1 { get; set; }
        public int Marks2 { get; set; }
        public void LinqEx(Student student)
        {
            var result=from p in new[] {student} select new {p.Name, Average=(p.Marks1+p.Marks2)/2.0, Highest=Math.Max(p.Marks1,p.Marks2)};
            foreach(var i in result)
            {
                Console.WriteLine($"Name: {i.Name}");
                Console.WriteLine($"Average Marks: {i.Average}");
                Console.WriteLine($"Highest Marks: {i.Highest}");
            }
        }
    }
    public class StudentMain
    {
        public static void Main(string[] args)
        {
            Student s = new Student()
            {
                Name = "Indra",
                Marks1 = 88,
                Marks2 = 90
            };
            s.LinqEx(s);
        }
    }
}
