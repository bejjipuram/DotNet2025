using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_18
{
    public class StudentGeneric
    {
        public string Name { get; set; }
        public int Mark1 { get; set; }
        public int Mark2 { get; set; }
        public void GenericLinq(List<StudentGeneric> students)
        {
            var result = from p in students select new { Name = p.Name, Average = (p.Mark1 + p.Mark2) / 2.0, Highest = Math.Max(p.Mark1, p.Mark2) };
            foreach (var stu in result)
            {
                Console.WriteLine($"Name: {stu.Name}");
                Console.WriteLine($"Average Marks: {stu.Average}");
                Console.WriteLine($"Highest Marks: {stu.Highest}");
            }
        }
    }
    public class GenericLinqMain
    {
        public static void Main(string[] args)
        {
            List<StudentGeneric> s = new List<StudentGeneric>
            {
                new StudentGeneric
                {
                    Name = "Indra",
                    Mark1 = 80,
                    Mark2 = 78
                }
            };
            StudentGeneric si = new StudentGeneric();
            si.GenericLinq(s);
        }
    }
}
