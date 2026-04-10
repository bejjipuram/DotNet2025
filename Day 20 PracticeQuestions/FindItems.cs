using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace CAP2025.Day_20
{
    public class FindItems
    {
        public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>()
        {
            {"Laptop", 150 },
            {"Mobile", 300 },
            {"Tablet", 100 },
            {"Headphone",30 },
            {"Keyboard",80 }
        };

        public static SortedDictionary<string,long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string, long> result = new SortedDictionary<string, long>();
            foreach(var item in itemDetails)
            {
                if (item.Value == soldCount)
                {
                    result.Add(item.Key, item.Value);
                }
            }
            return result;
        }
        public static List<string> FindMinandMaxSoldItems()
        {
            List<string> result = new List<string>();
            var minItem = itemDetails.OrderBy(x => x.Value).First();
            var maxItem = itemDetails.OrderByDescending(x => x.Value).First();
            result.Add(minItem.Key);
            result.Add(maxItem.Key);
            return result;
        }
        public static Dictionary<string,long> SortByCount()
        {
            Dictionary<string, long> result=itemDetails.OrderBy(x=>x.Value).ToDictionary(x=>x.Key, x=>x.Value);
            return result;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter sold count to search: ");
            long soldCount = long.Parse(Console.ReadLine());
            var result = FindItemDetails(soldCount);
            if (result.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                Console.WriteLine("Item Found: ");
                foreach(var item in result)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }
            List<string> minMaxItems = FindMinandMaxSoldItems();
            Console.WriteLine("\nMinimum Sold Item " + minMaxItems[0]);
            Console.WriteLine("\nMaximum Sold Item " + minMaxItems[1]);
            Console.WriteLine("\nItems sorted by sold count: ");
            Dictionary<string, long> sortedItems = SortByCount();
            foreach (var item in sortedItems)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}