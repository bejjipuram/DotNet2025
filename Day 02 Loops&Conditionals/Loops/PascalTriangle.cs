using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Use Nested Loops to print Pascal's triangle up to N rows.
    /// </summary>
    public class PascalTriangle
    {
        public static void Main()
        {
            Console.Write("Enter rows: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int val = 1;
                for (int s = 1; s <= n - i; s++)
                    Console.Write(" ");

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(val + " ");
                    val = val * (i - j) / (j + 1);
                }
                Console.WriteLine();
            }

        }
    }
}
