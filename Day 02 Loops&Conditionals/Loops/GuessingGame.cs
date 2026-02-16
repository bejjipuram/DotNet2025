using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day2.Loops
{
    /// <summary>
    /// Use do-while to let a user guess a secret number until they get it right.
    /// </summary>
    public class GuessingGame
    {
        public static void Main()
        {
            int secret = 7, guess;

            do
            {
                Console.Write("Guess number: ");
                guess = int.Parse(Console.ReadLine());
            } while (guess != secret);

            Console.WriteLine("Correct Guess!");

        }
    }
}
