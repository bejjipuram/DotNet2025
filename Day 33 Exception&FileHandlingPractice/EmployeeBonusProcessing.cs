using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_33_Exception_FileHandlingPractice
{
    public class BonusCalculator
    {
        public static void Main(string[] args)
        {
            int[] salaries = { 5000, 0, 7000 };
            int bonus = 10000;
            try
            {
                for (int i=0;i<salaries.Length;i++)
                {
                    try
                    {
                        int result =bonus/salaries[i];
                        Console.WriteLine($"Employee {i + 1}: Bonus calculation result = {result}");
                    }

                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($"Employee {i + 1}: Salary is zero, cannot calculate the bonus..");
                    }

                }
            }
            finally{
                Console.WriteLine("Bonus calculation completed for all the employees..");
            }
        }
    }
}
