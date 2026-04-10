using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CAP2025.Day_39_M1Practice
{
    public class ReflectionsEx
    {
        public static void Main(string[] args)
        {
            Type type = typeof(Person);
            Console.WriteLine("Name: " + type.Name);
            Console.WriteLine("Properties:\n");
            foreach(var p in type.GetProperties())
            {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Methods:\n");
            foreach(var p in type.GetMethods())
            {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine("Fields:\n");
            foreach(var p in fields)
            {
                //Console.WriteLine(p.Name);
                if (!p.Name.Contains("k__BackingField"))
                {
                    Console.WriteLine(p.Name);
                }
            }
        }
    }
}
