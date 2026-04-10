using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to check the winner of 2 players in rock, paper and scissors game
    /// </summary>
    public class RockPaperScissors
    {
        public static void Main()
        {
            Console.Write("Player 1 (R/P/S): ");
            char p1 = char.ToUpper(Console.ReadLine()[0]);
            Console.Write("Player 2 (R/P/S): ");
            char p2 = char.ToUpper(Console.ReadLine()[0]);

            if (p1 == p2)
                Console.WriteLine("Draw");
            else if ((p1 == 'R' && p2 == 'S') ||
                     (p1 == 'P' && p2 == 'R') ||
                     (p1 == 'S' && p2 == 'P'))
                Console.WriteLine("Player 1 Wins");
            else
                Console.WriteLine("Player 2 Wins");

        }
    }
}
