using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_42_M1Practice
{
    public class LeardBoardExample
    {
        public static void Main(string[] args)
        {
            List<(string name, int score)> players = new List<(string, int)>();
            Console.Write("Enter number of players: ");
            int playerCount = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 1; i <= playerCount; i++)
            {
                Console.WriteLine($"\nPlayer {i}: ");
                Console.Write("Enter Name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter Score: ");
                int score = int.Parse(Console.ReadLine());

                players.Add((name, score));
            }

            Console.Write("\nEnter value of K: ");
            int k = int.Parse(Console.ReadLine());

            var topK = players
                .OrderByDescending(p => p.score)
                .ThenBy(p => p.name)
                .Take(k)
                .ToList();

            Console.WriteLine("\n--- Top K Players ---");
            foreach (var player in topK)
            {
                Console.WriteLine($"Name: {player.name}, Score: {player.score}");
            }
        }
    }
}
