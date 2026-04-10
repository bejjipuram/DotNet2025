using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day1
{
    /// <summary>
    /// program to check whether the person is an adult or not based on the given input age
    /// </summary>
    public class AgeDistinguish
    {
        public static void Main()
        {
            Console.Write("Enter age: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int age))
            {
                bool isAdult = age >= 18;
                Console.WriteLine("Adult? " + isAdult);
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a whole number.");
            }
        }

    }
}
