using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// mplementing a deep-nested loop search that uses goto to exit all levels instantly upon finding a result.
    /// </summary>
    internal class SearchWithGoto
    {
        public static void Main()
        {
            int target = 7;
            bool found = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (i * j == target)
                    {
                        found = true;
                        goto end;
                    }
                }
            }

        end:
            Console.WriteLine(found ? "Target Found" : "Target Not Found");

        }
    }
}
