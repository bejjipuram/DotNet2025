using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Print a diamond shape using * characters with nested loops.
    /// </summary>
    public class DiamondPattern
    {
        public static void Main()
        {
            Console.Write("Enter size: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s <= n - i; s++) Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++) Console.Write("*");
                Console.WriteLine();
            }

            for (int i = n - 1; i >= 1; i--)
            {
                for (int s = 1; s <= n - i; s++) Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++) Console.Write("*");
                Console.WriteLine();
            }

        }
    }
}
