using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// class to print fibonacci series no of given terms
    /// </summary>
    public class Fibonacci
    {
        public static void Main()
        {
            int first_number = 0, second_number = 1, c;
            Console.WriteLine("Enter no of terms you want: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Console.Write(first_number + " ");
                c = first_number + second_number;
                first_number = second_number;
                second_number = c;
            }
        }
    }
}
