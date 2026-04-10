using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_41_M1Practice
{
    public class EmailEx
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the email to check: ");
            string? Email = Console.ReadLine();
            string[] parts = Email.Split('@');

            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid Email.");
                return;
            }
            string part1 = parts[0];
            string part2 = parts[1];
            foreach (var i in part1)
            { 
                if (Char.IsLetter(i) && Char.IsDigit(i))
                {
                    Console.WriteLine("Valid Email");
                    return;
                }
            }
            if (!part2.Equals("gmail.com"))
            {
                Console.WriteLine("Invalid Email.");
                return;
            }
            if (part1.Length == 0 && part1.Length>=64)
            {
                Console.WriteLine("Invalid Email");
                return;
            }
            Console.WriteLine("Valid Email");
        }
    }
}
