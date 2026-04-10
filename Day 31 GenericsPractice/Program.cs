using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace CAP2025.Day_31_GenericsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> marks = new List<int>() { 99, 45, 55, 65, 75, 85, 95 };

            // ---------------- PREDICATE ----------------
            Predicate<int> isPass = m => m >= 50;

            Console.WriteLine("Passed Marks:");
            foreach (var m in marks.FindAll(isPass))
            {
                Console.WriteLine(m);
            }

            // ---------------- ACTION ----------------
            Action<int> printMark = m =>
            {
                Console.WriteLine($"Mark: {m}");
            };

            Console.WriteLine("\nAll Marks:");
            marks.ForEach(printMark);



            Predicate<int> gradeAA= m => m >= 90;
            Predicate<int> gradeA = m => m >= 75 && m < 90;
            Predicate<int> gradeB = m => m >= 60 && m < 75;
            Predicate<int> gradeC = m => m >= 50 && m < 60;
            Predicate<int> gradeD = m => m >= 40 && m < 50;
            Console.WriteLine("\nGrades: ");
            foreach(var m in marks)
            {
                if (gradeAA(m))
                {
                    Console.WriteLine("A+");
                }
                else if (gradeA(m))
                {
                    Console.WriteLine("A");
                }
                else if (gradeB(m))
                {
                    Console.WriteLine("B");
                }
                else if (gradeC(m))
                {
                    Console.WriteLine("C");
                }
                else if (gradeD(m))
                {
                    Console.WriteLine("D");
                }
                else
                {
                    Console.WriteLine("Fail");
                }
            }

            /*

            // ---------------- FUNC ----------------
            Func<int, string> gradeCalculator = m =>
            {
                if (m >= 90) return "A+";
                else if (m >= 75) return "A";
                else if (m >= 60) return "B";
                else if (m >= 50) return "C";
                else return "Fail";
            };

            Console.WriteLine("\nGrades:");
            foreach (var m in marks)
            {
                Console.WriteLine($"{m} => {gradeCalculator(m)}");
            }
            */
        }
    }
}
