using System;
using System.Collections.Generic;

namespace CAP2025.Day_6
{
    /// <summary>
    /// 
    /// </summary>
    public class Semester
    {
        public int Number;
        public List<Student> Students = new List<Student>();
    }

    // ---------------- USER ----------------
    public class User
    {
        public string? Name;
    }

    // ---------------- EMPLOYEE ----------------
    public class Employee : User
    {
        public int EmpID;
        public string? Department;
    }

    // ---------------- STUDENT ----------------
    public class Student : User
    {
        public int RollNo;
        public Semester Semester;

        public Student(string name, int rollNo, Semester semester)
        {
            Name = name;
            RollNo = rollNo;
            Semester = semester;
        }
    }

    // ---------------- EXAM ----------------
    public class Exam
    {
        public string Subject;
        public Semester Semester;
        public DateTime ExamDate;
        public Examiner? AssignedExaminer;
    }

    // ---------------- EXAMINER ----------------
    public class Examiner : Employee
    {
        public Examiner(string name, int empId, string department)
        {
            Name = name;
            EmpID = empId;
            Department = department;
        }

        public void ConductExam(Exam exam)
        {
            Console.WriteLine(
                $"Examiner {Name} is conducting {exam.Subject} " +
                $"for Semester {exam.Semester.Number} on {exam.ExamDate:dd-MM-yyyy}"
            );
        }
    }

    // ---------------- HOD ----------------
    public class HOD : Employee
    {
        public HOD(string name, int empId, string department)
        {
            Name = name;
            EmpID = empId;
            Department = department;
        }

        public void ScheduleExams(List<Exam> exams)
        {
            Console.WriteLine($"\nHOD {Name} is scheduling exams:\n");

            foreach (var exam in exams)
            {
                Console.WriteLine(
                    $"Subject: {exam.Subject}, Semester: {exam.Semester.Number}, " +
                    $"Date: {exam.ExamDate:dd-MM-yyyy}"
                );
            }
        }

        public void AssignExaminer(Examiner examiner, Exam exam)
        {
            exam.AssignedExaminer = examiner;

            Console.WriteLine(
                $"\nHOD {Name} assigned Examiner {examiner.Name} " +
                $"for {exam.Subject}"
            );

            examiner.ConductExam(exam);
        }
    }

    // ---------------- MAIN ----------------
    class ExamScheduleMain
    {
        static void Main(string[] args)
        {
            // Semester
            Semester semester3 = new Semester { Number = 3 };

            // Students
            semester3.Students.Add(new Student("Ravi", 101, semester3));
            semester3.Students.Add(new Student("Anita", 102, semester3));
            semester3.Students.Add(new Student("Kiran", 103, semester3));

            // HOD
            HOD hod = new HOD("Dr. Sharma", 1001, "Computer Science");

            // Examiner
            Examiner examiner1 = new Examiner("Dr. ABC", 2001, "Computer Science");

            // Exams
            List<Exam> exams = new List<Exam>
            {
                new Exam
                {
                    Subject = "Data Structures",
                    Semester = semester3,
                    ExamDate = new DateTime(2025, 3, 25)
                },
                new Exam
                {
                    Subject = "Operating Systems",
                    Semester = semester3,
                    ExamDate = new DateTime(2025, 3, 27)
                }
            };

            // Schedule exams
            hod.ScheduleExams(exams);

            // Assign examiner
            foreach (var exam in exams)
            {
                hod.AssignExaminer(examiner1, exam);
            }

            // Display students
            Console.WriteLine("\nStudents Appearing for Semester 3 Exams:");
            foreach (var student in semester3.Students)
            {
                Console.WriteLine($"RollNo: {student.RollNo}, Name: {student.Name}");
            }
        }
    }
}
