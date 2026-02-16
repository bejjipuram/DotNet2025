using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// Program to describe the performance based on the given input grade
    /// </summary>
    public class GradeDescription
    {
        public static void Main()
        {
            Console.Write("Enter Grade (E/V/G/A/F): ");
            char grade = char.ToUpper(Console.ReadLine()[0]);

            switch (grade)
            {
                case 'E': Console.WriteLine("Excellent"); break;
                case 'V': Console.WriteLine("Very Good"); break;
                case 'G': Console.WriteLine("Good"); break;
                case 'A': Console.WriteLine("Average"); break;
                case 'F': Console.WriteLine("Fail"); break;
                default: Console.WriteLine("Invalid Grade"); break;
            }

        }
    }
}
