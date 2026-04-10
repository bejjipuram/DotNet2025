using CAP2025.ExamTestSchedule.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.ExamTestSchedule.Databank
{
    static class DataBank
    {
        public static List<Student> Students = new List<Student>();
        public static List<StudentSession> studentSessions = new List<StudentSession>();
        static DataBank()
        {
            Students.Add(new Student() { Id = 1, Name = "Indra" });
            Students.Add(new Student() { Id = 2, Name = "Vijay" });
            Students.Add(new Student() { Id = 3, Name = "Prabhu" });
            Students.Add(new Student() { Id = 4, Name = "Immanuel" });

            studentSessions.Add(new StudentSession() { SessionId = "2025CS1", SessionName = "Cloud1" });
            studentSessions.Add(new StudentSession() { SessionId = "2025CS2", SessionName = "IOT-1" });
            studentSessions.Add(new StudentSession() { SessionId = "2025CS3", SessionName = "Web1" });
            studentSessions.Add(new StudentSession() { SessionId = "2025CS4", SessionName = "ML1" });
        }
        
        public static List<Student> GetStudents()
        {
            return Students;
        }
        public static List<StudentSession> GetStudentSessions()
        {
            return studentSessions;
        }
    }
}
