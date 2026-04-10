using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Repeatedly sum digits of a number until the result is a single digit (Digital Root)
    /// </summary>
    public class SumOfDigits
    {
        public static void Main()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            while (n >= 10)
            {
                int sum = 0;
                while (n > 0)
                {
                    sum += n % 10;
                    n /= 10;
                }
                n = sum;
            }

            Console.WriteLine("Digital Root = " + n);

        }
    }
}
