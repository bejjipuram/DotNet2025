//using System;

//namespace CAP2025.Day_6
//{
//    /// <summary>
//    /// Represents an academic semester.
//    /// </summary>
//    public class Semester
//    {
//        /// <summary>
//        /// Semester number (e.g., 1, 2, 3).
//        /// </summary>
//        public int Number;
//    }

//    /// <summary>
//    /// Base class representing a system user.
//    /// </summary>
//    public class User
//    {
//        /// <summary>
//        /// Name of the user.
//        /// </summary>
//        public string? Name;
//    }

//    /// <summary>
//    /// Represents an employee in the institution.
//    /// Inherits from User.
//    /// </summary>
//    public class Employee : User
//    {
//        /// <summary>
//        /// Employee ID.
//        /// </summary>
//        public int EmpID;

//        /// <summary>
//        /// Department of the employee.
//        /// </summary>
//        public string? Department;
//    }

//    /// <summary>
//    /// Represents a student.
//    /// Inherits from User.
//    /// </summary>
//    public class Student : User
//    {
//        /// <summary>
//        /// Roll number of the student.
//        /// </summary>
//        public int RollNo;

//        /// <summary>
//        /// Semester number in which the student is enrolled.
//        /// </summary>
//        public int Semester;

//        /// <summary>
//        /// Constructor to initialize student details.
//        /// </summary>
//        public Student(string nameInput, int rollNoInput)
//        {
//            Name = nameInput;
//            RollNo = rollNoInput;
//        }
//    }

//    /// <summary>
//    /// Represents the Head of Department (HOD).
//    /// Responsible for scheduling exams and assigning examiners.
//    /// </summary>
//    public class HOD : Employee
//    {
//        /// <summary>
//        /// Constructor to initialize HOD details.
//        /// </summary>
//        public HOD(string nameInput, int empIDInput, string departmentInput)
//        {
//            Name = nameInput;
//            EmpID = empIDInput;
//            Department = departmentInput;
//        }

//        /// <summary>
//        /// Schedules an exam for a given semester and date.
//        /// </summary>
//        public void ScheduleExam(Semester semester, Exam exam)
//        {
//            Console.WriteLine(
//                $"Exam for {exam.Subject} (Semester {semester.Number}) " +
//                $"is scheduled on {exam.ExamDate:dd-MM-yyyy} by HOD {Name}"
//            );
//        }

//        /// <summary>
//        /// Assigns an examiner to an exam.
//        /// </summary>
//        public void AssignExaminer(Examiner examiner, Exam exam)
//        {
//            exam.AssignedExaminer = examiner;
//            Console.WriteLine(
//                $"HOD {Name} has assigned Examiner {examiner.Name} for subject {exam.Subject}"
//            );
//            examiner.ConductExam(exam);
//        }
//    }

//    /// <summary>
//    /// Represents an examiner responsible for conducting exams.
//    /// </summary>
//    public class Examiner : Employee
//    {
//        /// <summary>
//        /// Constructor to initialize examiner details.
//        /// </summary>
//        public Examiner(string nameInput, int empIDInput, string departmentInput)
//        {
//            Name = nameInput;
//            EmpID = empIDInput;
//            Department = departmentInput;
//        }

//        /// <summary>
//        /// Conducts the assigned exam.
//        /// </summary>
//        public void ConductExam(Exam exam)
//        {
//            Console.WriteLine(
//                $"Exam for {exam.Subject} is being conducted by {Name} " +
//                $"on {exam.ExamDate:dd-MM-yyyy}"
//            );
//        }
//    }

//    /// <summary>
//    /// Represents an exam with subject, semester, date, and assigned examiner.
//    /// </summary>
//    public class Exam
//    {
//        /// <summary>
//        /// Subject name of the exam.
//        /// </summary>
//        public string? Subject;

//        /// <summary>
//        /// Semester associated with the exam.
//        /// </summary>
//        public Semester? Semester;

//        /// <summary>
//        /// Date on which the exam is conducted.
//        /// </summary>
//        public DateTime ExamDate;

//        /// <summary>
//        /// Examiner assigned to the exam.
//        /// </summary>
//        public Examiner? AssignedExaminer;
//    }

//    /// <summary>
//    /// Entry point of the Exam Scheduling application.
//    /// </summary>
//    public class ExamScheduleMain
//    {
//        static void Main(string[] args)
//        {
//            HOD hod = new HOD("Dr. Hod", 101, "Computer Science");
//            Examiner examiner = new Examiner("ABC", 201, "Computer Science");

//            Semester semester = new Semester { Number = 3 };

//            Exam exam = new Exam
//            {
//                Subject = "Data Structures",
//                Semester = semester,
//                ExamDate = new DateTime(2025, 3, 25)
//            };

//            hod.ScheduleExam(semester, exam);
//            hod.AssignExaminer(examiner, exam);
//        }
//    }
//}
