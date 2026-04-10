using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_32_M1Practice
{
    public class CreatorStats
    {
        // Public properties
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }

        // Static engagement board
        public static List<CreatorStats> EngagementBoard { get; } = new List<CreatorStats>();

        // Constructor
        public CreatorStats(string creatorName, double[] weeklyLikes)
        {
            CreatorName = creatorName;
            WeeklyLikes = weeklyLikes;
        }
    }

    public class StreamBuzzMain
    {
        // Registers a creator record into EngagementBoard
        public void RegisterCreator(CreatorStats record)
        {
            CreatorStats.EngagementBoard.Add(record);
        }

        // Counts weeks where likes >= threshold for each creator
        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var creator in records)
            {
                int count = 0;

                foreach (var likes in creator.WeeklyLikes)
                {
                    if (likes >= likeThreshold)
                    {
                        count++;
                    }
                }

                // Add creator only if threshold met at least once
                if (count > 0)
                {
                    result[creator.CreatorName] = count;
                }
            }

            return result;
        }

        // Calculates average of all weekly likes across all creators
        public double CalculateAverageLikes()
        {
            double totalLikes = 0;
            int totalWeeks = 0;

            foreach (var creator in CreatorStats.EngagementBoard)
            {
                foreach (var likes in creator.WeeklyLikes)
                {
                    totalLikes += likes;
                    totalWeeks++;
                }
            }

            if (totalWeeks == 0)
                return 0;

            return Math.Round(totalLikes / totalWeeks);
        }

        // Main method
        public static void Main(string[] args)
        {
            StreamBuzzMain p = new StreamBuzzMain();

            while (true)
            {
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show Top Posts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Enter Creator Name:");
                    string? name = Console.ReadLine();

                    double[] likes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                    for (int i = 0; i < 4; i++)
                    {
                        likes[i] = double.Parse(Console.ReadLine()!);
                    }

                    CreatorStats record = new CreatorStats(name ?? "", likes);
                    p.RegisterCreator(record);

                    Console.WriteLine("Creator registered successfully");
                    Console.WriteLine();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine()!);

                    Dictionary<string, int> result =
                        p.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    Console.WriteLine();
                }
                else if (choice == "3")
                {
                    double avg = p.CalculateAverageLikes();
                    Console.WriteLine($"Overall average weekly likes: {avg}");
                    Console.WriteLine();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    break;
                }
            }
        }
    }

}
