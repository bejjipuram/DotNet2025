using System;
using System.Collections.Generic;

namespace CAP2025.Day_31_GenericsPractice
{
    // Delegate
    public delegate void StudentResultHandler(string name, double marks);

    // Generic Student class
    public class GenericStudent<TName, TMarks>
    {
        public TName name;
        public TMarks marks;

        public GenericStudent(TName name, TMarks marks)
        {
            this.name = name;
            this.marks = marks;
        }
    }

    public class GenericStuMain
    {
        // Events
        public static event StudentResultHandler Notify;

        // Event handler methods
        public static void FailedStudent(string name, double marks)
        {
            Console.WriteLine($"{name} has FAILED with {marks} marks");
        }

        public static void AverageStudent(string name, double marks)
        {
            Console.WriteLine($"{name} is AVERAGE with {marks} marks");
        }

        public static void GoodStudent(string name, double marks)
        {
            Console.WriteLine($"{name} is a GOOD student with {marks} marks");
        }

        public static void ExcellentStudent(string name, double marks)
        {
            Console.WriteLine($"{name} is an EXCELLENT student with {marks} marks");
        }

        // Business logic
        public static double FindAverage(List<GenericStudent<string, double>> students)
        {
            double sum = 0;

            foreach (var s in students)
            {
                sum += s.marks;

                if (s.marks>= 700)
                {
                    Notify = ExcellentStudent;
                }
                else if (s.marks>=600 && s.marks <= 650)
                {
                    Notify = GoodStudent;
                }
                else if (s.marks>=500 && s.marks < 599)
                {
                    Notify = AverageStudent;
                }
                else
                {
                    Notify = FailedStudent;
                }
                Notify?.Invoke(s.name, s.marks);
            }

            return sum / students.Count;
        }

        public static void Main(string[] args)
        {

            List<GenericStudent<string, double>> students =
                new List<GenericStudent<string, double>>()
                {
                    new GenericStudent<string, double>("Indra", 590),
                    new GenericStudent<string, double>("Viswa", 610),
                    new GenericStudent<string, double>("Vardhan", 645),
                    new GenericStudent<string, double>("Gopal", 680),
                    new GenericStudent<string, double>("Aryan", 750)
                };

            double avg = FindAverage(students);
            Console.WriteLine("\nAverage marks of students: " + avg);
        }
    }
}
