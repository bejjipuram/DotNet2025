using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to check whether the give input date is valid or not including the leap year(Feb 29)
    /// </summary>
    public class ValidDateCheck
    {
        public static void Main()
        {
            Console.Write("Enter day, month, year: ");
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool leap = (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
            int[] days = { 31, leap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (m >= 1 && m <= 12 && d >= 1 && d <= days[m - 1])
                Console.WriteLine("Valid Date");
            else
                Console.WriteLine("Invalid Date");

        }
    }
}
