using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Use do-while and switch to create a persistent console menu
    /// </summary>
    public class MenuSystem
    {
        public static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n1.Add  2.Sub  3.Exit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Console.WriteLine("Addition"); break;
                    case 2: Console.WriteLine("Subtraction"); break;
                    case 3: Console.WriteLine("Exit"); break;
                    default: Console.WriteLine("Invalid"); break;
                }
            } while (choice != 3);

        }
    }
}
