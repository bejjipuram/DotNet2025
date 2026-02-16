using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Check if a number equals the sum of its digits raised to the power of number of digits.
    /// </summary>
    public class ArmstrongNumber
    {
        public static void Main()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            int temp = num, digits = 0;
            while (temp > 0)
            {
                digits++;
                temp /= 10;
            }

            temp = num;
            int sum = 0;
            while (temp > 0)
            {
                int d = temp % 10;
                int pow = 1;
                for (int i = 1; i <= digits; i++)
                    pow *= d;
                sum += pow;
                temp /= 10;
            }

            Console.WriteLine(sum == num ? "Armstrong Number" : "Not Armstrong");

        }
    }
}
