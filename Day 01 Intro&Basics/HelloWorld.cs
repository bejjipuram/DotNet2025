using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day1
{
    /// <summary>
    /// program to print hello name(which is an user input)
    /// </summary>
    public class HelloWorld
    {
        public static void Main()
        {
            Console.WriteLine("Enter your name: ");
            string? name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
        }

    }
}
