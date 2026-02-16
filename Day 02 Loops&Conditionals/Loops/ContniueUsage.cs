using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Print numbers from 1 to 50, but skip all multiples of 3 using continue
    /// </summary>
    public class ContniueUsage
    {
        public static void Main()
        {
            for (int i = 1; i <= 50; i++)
            {
                if (i % 3 == 0)
                    continue;

                Console.Write(i + " ");
            }

        }
    }
}
