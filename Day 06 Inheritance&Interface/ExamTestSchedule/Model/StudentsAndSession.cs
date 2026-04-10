using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.ExamTestSchedule.Model
{
    public class StudentsAndSession
    {
        public StudentSession session { get; set; }
        public List<Student> SessionStudents { get; set; }
        public StudentsAndSession()
        {

        }
    }
}
