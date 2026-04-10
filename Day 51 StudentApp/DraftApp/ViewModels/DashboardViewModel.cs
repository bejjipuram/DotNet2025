using DraftApp.Models;
using System.Collections.Generic;

namespace DraftApp.ViewModels
{
    public class DashboardViewModel
    {
        public List<Student> Students { get; set; }

        public List<Course> Courses { get; set; }

        public List<Enrollment> Enrollments { get; set; }

        public int TotalStudents { get; set; }

        public int TotalCourses { get; set; }

        public int TotalEnrollments { get; set; }
    }
}