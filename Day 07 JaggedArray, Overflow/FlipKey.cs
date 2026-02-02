using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_7
{
    public class FlipKey
    {
        public static string CleanseAndInvert(string inp)
        {
            inp = inp.ToLower();
            string outputstring = "";
            if (inp.Length < 6)
            {
                return "Invalid";
            }
            for (int i = 0; i < inp.Length; i++)
            {
                if (((int)inp[i] >= 65 && (int)inp[i] <= 90) || ((int)inp[i] >= 97 && (int)inp[i] <= 122))
                {
                    if ((int)inp[i] % 2 == 0)
                    {

                    }
                    else
                    {
                        outputstring += inp[i];
                    }
                }
                else
                {
                    return "invalid input";
                }
            }
            char[] arr = outputstring.ToCharArray();
            Array.Reverse(arr);
            return outputstring;

        }
        public static void Main(string[] args)
        {
            string? input;
            Console.Write("Enter the Input String: ");
            input = Console.ReadLine();
            string newstring = CleanseAndInvert(input);
            Console.WriteLine("The Final Output is: " + newstring);
        }
    }

}
