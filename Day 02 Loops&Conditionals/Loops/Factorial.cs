using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Calculate N! and handle potential overflow for larger integers
    /// </summary>
    public class Factorial
    {
        public static void Main()
        {

            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            BigInteger fact = 1;
            for (int i = 1; i <= n; i++)
                fact *= i;

            Console.WriteLine("Factorial = " + fact);

        }
    }
}
