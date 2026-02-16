using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_42_M1Practice
{
    public class AttendanceManagement
    {
        public static void Main(string[] args)
        {
            HashSet<int> seenIds = new HashSet<int>();
            List<int> firstEntries = new List<int>();

            Console.WriteLine("Enter number of attendance entries: ");
            int entryCount = int.Parse(Console.ReadLine()?? "0");

            for (int i = 1; i <= entryCount; i++)
            {
                Console.WriteLine($"Enter employee ID for entry {i}: ");
                int empId = int.Parse(Console.ReadLine() ?? "0");

                if (!seenIds.Contains(empId))
                {
                    seenIds.Add(empId);
                    firstEntries.Add(empId);
                }
            }

            Console.WriteLine("\nUnique Employee IDs in order of first entry:");
            foreach (int id in firstEntries)
            {
                Console.Write(id + " ");
            }
            Console.WriteLine();
        }
    }
}
