using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Find the Greatest Common Divisor and Least Common Multiple of two numbers.
    /// </summary>
    public class GCDLCM
    {
        public static void Main()
        {
            Console.Write("Enter two numbers: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int x = a, y = b;
            while (y != 0)
            {
                int r = x % y;
                x = y;
                y = r;
            }

            int gcd = x;
            int lcm = (a * b) / gcd;

            Console.WriteLine("GCD = " + gcd);
            Console.WriteLine("LCM = " + lcm);

        }
    }
}
