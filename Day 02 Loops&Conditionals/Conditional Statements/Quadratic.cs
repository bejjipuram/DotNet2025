using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to calculate the roots of the quadratic equation
    /// </summary>
    public class Quadratic
    {
        public static void Main()
        {
            Console.Write("Enter a, b, c: \n");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double d = b * b - 4 * a * c;

            if (d > 0)
            {
                double r1 = (-b + Math.Sqrt(d)) / (2 * a);
                double r2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("Roots are real and different: " + r1 + ", " + r2);
            }
            else if (d == 0)
            {
                double r = -b / (2 * a);
                Console.WriteLine("Roots are real and same: " + r);
            }
            else
            {
                Console.WriteLine("Roots are imaginary");
            }
        }
    }
}
