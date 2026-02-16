using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to check whether the given letter or character is a vowel or a consonant
    /// </summary>
    public class VowelConsonantSwitch
    {
        public static void Main()
        {
            Console.Write("Enter a character: ");
            char ch = char.ToLower(Console.ReadLine()[0]);

            switch (ch)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine("Vowel");
                    break;
                default:
                    Console.WriteLine("Consonant");
                    break;
            }

        }


    }
}
