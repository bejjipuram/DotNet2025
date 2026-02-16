using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CAP2025.Day_42_M1Practice
{
    public class StringReverse
    {

    }
    public class StringReverseMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the string: ");
            string? input = Console.ReadLine();
            char[] reversed = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                reversed[i] = input[input.Length - 1 - i];
            }
            Console.WriteLine(new string(reversed));

        }
    }
}
