using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// class to check whether the given year is leap year or not
    /// </summary>
    public class LeapY
    {
        public static void Main()
        {
            Console.WriteLine("Enter the year");
            int a = Convert.ToInt32(Console.ReadLine());
            if(a%400==0 || (a%4==0 && a != 0))
            {
                Console.WriteLine($"{a} is a leap year");
            }
            else
            {
                Console.WriteLine($"{a} is not a leap year");
            }
        }
    }
}
