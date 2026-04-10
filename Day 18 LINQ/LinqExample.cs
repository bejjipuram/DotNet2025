using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_18
{
    public class LinqExample
    {
        public class LinqStudent
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
        
        //public LinqExample(string name)
        //{
        //    string[] names = { "A", "B", "C", "D" };
        //    var findname = from item in names where item == name select item;
        //    if (findname != null)
        //    {
        //        Console.WriteLine($"Found name {name}");
        //    }
        //}
        public void LinqEx(string name)
        {
            string[] names = { "Eve", "Ananth", "Indra", "Viswa", "Vardhan", "Gopal" };
            var findname = from item in names orderby item ascending select new LinqStudent() { Name=item};
            foreach(var items in findname)
            {
                Console.WriteLine(items.Name);
            }
            Console.ReadLine();
        }

        //public static void LinqEx1()
        //{
        //    var proCollection = from p in System.Diagnostics.Process.GetProcesses() select new MyProcess() { Name = p.ProcessName, Id = p.Id };
        //    foreach(var pro in proCollection)
        //    {
        //        Console.WriteLine($"Process Name= {pro.Name} Id= {pro.Id}");
        //    }
        //}
        public static void LinqEx2()
        {
            var proCollection = from p in System.Diagnostics.Process.GetProcesses() select new { Name = p.ProcessName, Id = p.Id };
            //Anonymous data types because we havent given the class, so microsoft will decide the data type based on the values it is taking
            foreach (var pro in proCollection)
            {
                Console.WriteLine($"Process Name= {pro.Name} Id= {pro.Id}");
            }
        }
        //public static string IsPalindrome(string name)
        //{
        //    string tempname = name.ToLower();
        //    if (new string(tempname.Reverse().ToArray()) == tempname)
        //    {
        //        return $"{name} is a Palindrome.";
        //    }
        //    return $"{name} is not a Palindrome.";
        //}
    }
    public class MyProcess
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class LinqMain
    {
        public static void Main(string[] args)
        {
            //LinqExample linq = new LinqExample();
            LinqExample.LinqEx2();
            //LinqExample.LinqEx("Sun");

        }
    }
}
//model account is there in that account number, holder name, ifsc code and many, but when we display them on the screen we need to hide few things like account number then we use anonymous class
//in view class/model the properties are only for the displaying the values on the screen
//instead of creating another class for midifing the data, the anonymous will hide them automatically or we can ignore few properties to be printed on the screen