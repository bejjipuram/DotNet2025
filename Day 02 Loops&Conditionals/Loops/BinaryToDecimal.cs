using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Convert a binary number string to decimal without using built-in library functions.
    /// </summary>
    public class BinaryToDecimal
    {
        public static void Main()
        {
            Console.Write("Enter binary number: ");
            string bin = Console.ReadLine();

            int dec = 0, baseVal = 1;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                if (bin[i] == '1')
                    dec += baseVal;
                baseVal *= 2;
            }

            Console.WriteLine("Decimal = " + dec);

        }
    }
}
