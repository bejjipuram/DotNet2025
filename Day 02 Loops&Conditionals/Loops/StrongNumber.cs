using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Check if the sum of the factorial of digits is equal to the number itself
    /// </summary>
    public class StrongNumber
    {
        public static void Main()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());
            int temp = n, sum = 0;

            while (temp > 0)
            {
                int d = temp % 10;
                int fact = 1;
                for (int i = 1; i <= d; i++)
                    fact *= i;
                sum += fact;
                temp /= 10;
            }

            Console.WriteLine(sum == n ? "Strong Number" : "Not Strong");

        }
    }
}
