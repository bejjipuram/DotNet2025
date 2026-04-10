using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CAP2025.Day_12
{
    public class JSONStudent
    {
        public string name { get; set; }
        public int[] marks { get; set; }
        public JSONStudent()
        {

        }
    }
    public class JSONMain
    {
        public static void Main(string[] args)
        {
            JSONStudent stu = new JSONStudent();
            stu.name = "Indra";
            stu.marks = new int[] { 34, 56, 77, 64, 69 };
            string jsout = JsonSerializer.Serialize(stu);
            Console.WriteLine(jsout);
        }
    }
}
