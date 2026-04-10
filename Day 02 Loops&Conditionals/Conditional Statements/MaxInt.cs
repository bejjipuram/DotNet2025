using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// class to check the maximum integers from the inputs
    /// </summary>
    public class MaxInt
    {
        public static void Main()
        {
            int a, b, c;
            Console.WriteLine("Enter the first number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the third number: ");
            c = Convert.ToInt32(Console.ReadLine());
            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine($"{a} is maximum");
                }
                else
                {
                    Console.WriteLine($"{c} is maximum");
                }
            }
            else
            {
                if (b > c)
                {
                    Console.WriteLine($"{b} is maximum");
                }
                else
                {
                    Console.WriteLine($"{c} is maximum");
                }
            }
        }
    }
}
