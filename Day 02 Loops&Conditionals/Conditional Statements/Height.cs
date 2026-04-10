using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// class to check the height variations
    /// </summary>
    public class Height
    {
        public static void Main()
        {
            string? choice = "y";
            while (choice == "y")
            {
                Console.WriteLine("Enter the Height in cm: ");
                double height = Convert.ToDouble(Console.ReadLine());
                if (height < 150)
                {
                    Console.WriteLine("Dwarf");
                }
                else if (height >= 150 && height < 165)
                {
                    Console.WriteLine("Average");
                }
                else if (height >= 165 && height < 190)
                {
                    Console.WriteLine("Tall");
                }
                else
                {
                    Console.WriteLine("Abnormal");
                }
                Console.WriteLine("Do you wanna continue(y/n): ");
                choice = Console.ReadLine();
            }
        }
    }
}
