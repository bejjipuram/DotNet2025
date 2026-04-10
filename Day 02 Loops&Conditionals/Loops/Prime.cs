using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to check whether the given number is prime or not
    /// </summary>
    public class Prime
    {
        public static void Main()
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            bool prime = true;

            if (n <= 1)
                prime = false;
            else
            {
                for (int i = 2; i <= n / 2; i++)
                {
                    if (n % i == 0)
                    {
                        prime = false;
                        break;
                    }
                }
            }

            Console.WriteLine(prime ? "Prime Number" : "Not Prime");


        }
    }
}
