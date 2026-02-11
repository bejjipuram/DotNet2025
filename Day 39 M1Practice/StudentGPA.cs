using System;
using System.Collections.Generic;
using System.Linq;

namespace CAP2025.Day_39_M1Practice
{
    // ===============================
    // 1. Base Interfaces
    // ===============================
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        int Semester { get; }
    }

    public interface ICourse
    {
        string CourseCode { get; }
        string Title { get; }
        int MaxCapacity { get; }
        int Credits { get; }
    }

    // Optional prerequisite contract
    public interface IPrerequisiteCourse
    {
        int RequiredSemester { get; }
    }

    // ===============================
    // 2. Generic Enrollment System
    // ===============================
    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly Dictionary<TCourse, List<TStudent>> _enrollments = new();

        public bool EnrollStudent(TStudent student, TCourse course, out string message)
        {
            if (!_enrollments.ContainsKey(course))
                _enrollments[course] = new List<TStudent>();

            var students = _enrollments[course];

            // Capacity check
            if (students.Count >= course.MaxCapacity)
            {
                message = "Enrollment failed: Course at full capacity.";
                return false;
            }

            // Duplicate enrollment check
            if (students.Any(s => s.StudentId == student.StudentId))
            {
                message = "Enrollment failed: Student already enrolled.";
                return false;
            }

            // Prerequisite check (if course has prerequisite)
            if (course is IPrerequisiteCourse prereq)
            {
                if (student.Semester < prereq.RequiredSemester)
                {
                    message = $"Enrollment failed: Requires semester {prereq.RequiredSemester}.";
                    return false;
                }
            }

            students.Add(student);
            message = "Enrollment successful.";
            return true;
        }

        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
        {
            if (_enrollments.TryGetValue(course, out var students))
                return students.AsReadOnly();

            return new List<TStudent>().AsReadOnly();
        }

        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        {
            return _enrollments
                .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
                .Select(e => e.Key);
        }

        public int CalculateStudentWorkload(TStudent student)
        {
            return GetStudentCourses(student).Sum(c => c.Credits);
        }
    }

    // ===============================
    // 3. Specialized Implementations
    // ===============================
    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }

        public override string ToString()
            => $"{Name} (Sem {Semester}, {Specialization})";
    }

    public class LabCourse : ICourse, IPrerequisiteCourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public string LabEquipment { get; set; }
        public int RequiredSemester { get; set; }

        public override string ToString()
            => $"{CourseCode} - {Title}";
    }

    // ===============================
    // 4. Generic GradeBook
    // ===============================
    public class GradeBook<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;
        private readonly Dictionary<(int studentId, string courseCode), double> _grades = new();

        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
        {
            _enrollmentSystem = enrollmentSystem;
        }

        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            var enrolledCourses = _enrollmentSystem.GetStudentCourses(student);
            if (!enrolledCourses.Any(c => c.CourseCode == course.CourseCode))
                throw new InvalidOperationException("Student not enrolled in course.");

            _grades[(student.StudentId, course.CourseCode)] = grade;
        }

        public double? CalculateGPA(TStudent student)
        {
            var courses = _enrollmentSystem.GetStudentCourses(student).ToList();
            if (!courses.Any()) return null;

            double totalWeighted = 0;
            int totalCredits = 0;

            foreach (var course in courses)
            {
                if (_grades.TryGetValue((student.StudentId, course.CourseCode), out var grade))
                {
                    totalWeighted += grade * course.Credits;
                    totalCredits += course.Credits;
                }
            }

            if (totalCredits == 0) return null;

            return totalWeighted / totalCredits;
        }

        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            var students = _enrollmentSystem.GetEnrolledStudents(course);

            var gradedStudents = students
                .Where(s => _grades.ContainsKey((s.StudentId, course.CourseCode)))
                .Select(s => (student: s,
                              grade: _grades[(s.StudentId, course.CourseCode)]))
                .OrderByDescending(g => g.grade)
                .FirstOrDefault();

            if (gradedStudents.student == null)
                return null;

            return gradedStudents;
        }
    }

    // ===============================
    // 5. TEST SCENARIO
    // ===============================
    public class StudentGPA
    {
        public static void Main()
        {
            var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
            var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

            // Students
            var s1 = new EngineeringStudent { StudentId = 1, Name = "Indra", Semester = 3, Specialization = "Cloud" };
            var s2 = new EngineeringStudent { StudentId = 2, Name = "Rahul", Semester = 2, Specialization = "AI" };
            var s3 = new EngineeringStudent { StudentId = 3, Name = "Sneha", Semester = 4, Specialization = "Data" };

            // Courses
            var c1 = new LabCourse
            {
                CourseCode = "CS301",
                Title = "Advanced Cloud Lab",
                MaxCapacity = 2,
                Credits = 4,
                RequiredSemester = 3
            };

            var c2 = new LabCourse
            {
                CourseCode = "CS201",
                Title = "AI Fundamentals Lab",
                MaxCapacity = 1,
                Credits = 3,
                RequiredSemester = 2
            };

            // Enrollment Tests
            Console.WriteLine(enrollment.EnrollStudent(s1, c1, out var msg1) + " - " + msg1);
            Console.WriteLine(enrollment.EnrollStudent(s2, c1, out var msg2) + " - " + msg2); // fail (semester)
            Console.WriteLine(enrollment.EnrollStudent(s3, c1, out var msg3) + " - " + msg3);
            Console.WriteLine(enrollment.EnrollStudent(s1, c1, out var msg4) + " - " + msg4); // duplicate
            Console.WriteLine(enrollment.EnrollStudent(s2, c2, out var msg5) + " - " + msg5);
            Console.WriteLine(enrollment.EnrollStudent(s3, c2, out var msg6) + " - " + msg6); // capacity fail

            // Assign Grades
            gradeBook.AddGrade(s1, c1, 85);
            gradeBook.AddGrade(s3, c1, 92);
            gradeBook.AddGrade(s2, c2, 88);

            // GPA
            Console.WriteLine($"\nGPA of {s1.Name}: {gradeBook.CalculateGPA(s1)}");
            Console.WriteLine($"GPA of {s3.Name}: {gradeBook.CalculateGPA(s3)}");

            // Top Student
            var top = gradeBook.GetTopStudent(c1);
            if (top.HasValue)
                Console.WriteLine($"\nTop student in {c1.Title}: {top.Value.student.Name} with {top.Value.grade}");
        }
    }
}
