using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to check the given triangle is an equilateral or isosceles or a scalene triangle based on the given inputs
    /// </summary>
    public class Triangle
    {
        public static void Main()
        {
            Console.Write("Enter three sides: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a == b && b == c)
                Console.WriteLine("Equilateral Triangle");
            else if (a == b || b == c || a == c)
                Console.WriteLine("Isosceles Triangle");
            else
                Console.WriteLine("Scalene Triangle");

        }
    }
}
