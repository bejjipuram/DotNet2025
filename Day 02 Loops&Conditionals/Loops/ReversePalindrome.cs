using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Reverse an integer and check if it is a palindrome using while
    /// </summary>
    public class ReversePalindrome
    {
        public static void Main()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            int rev = 0, temp = n;
            while (temp > 0)
            {
                rev = rev * 10 + temp % 10;
                temp /= 10;
            }

            Console.WriteLine("Reverse = " + rev);
            Console.WriteLine(rev == n ? "Palindrome" : "Not Palindrome");

        }
    }
}
