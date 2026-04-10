using System;
using System.Collections.Generic;
using System.Text;
using CAP2025.ExamTestSchedule.Databank;

namespace CAP2025.ExamTestSchedule
{
    public class ScheduleMain
    {
        public static void Main(string[] args)
        {
            //List<Student> localStudents = DataBank.GetStudents();
            var localStudents = DataBank.GetStudents();
            var localSessions = DataBank.GetStudentSessions();
            Console.WriteLine("Session Details: \n");
            Console.WriteLine("Id      Name");
            foreach (var j in localSessions)
            {
                Console.WriteLine(j.SessionId+ " "+j.SessionName);
            }
            Console.WriteLine("\nStudents Details: \n");
            foreach (var i in localStudents)
            {
                Console.WriteLine(i.Id+" "+ i.Name);
            }
        }
    }
}
