using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to check in which quadrant the given coordinators are lie in.
    /// </summary>
    public class Quadrant
    {
        public static void Main()
        {
            Console.Write("Enter x and y: ");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if (x > 0 && y > 0)
                Console.WriteLine("First Quadrant");
            else if (x < 0 && y > 0)
                Console.WriteLine("Second Quadrant");
            else if (x < 0 && y < 0)
                Console.WriteLine("Third Quadrant");
            else if (x > 0 && y < 0)
                Console.WriteLine("Fourth Quadrant");
            else
                Console.WriteLine("On Axis");

        }
    }
}
