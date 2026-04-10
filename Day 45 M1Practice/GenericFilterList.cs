using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class GenericFilterList
    {
        public static void Main(string[] args)
        {
            var nums = new List<int> { 2, 5, 8, 11, 14 };
            var evens = Filter(nums, n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", evens));
            var big = Filter(nums, n => n >= 10);
            Console.WriteLine(string.Join(", ", big));
        }
        public static List<T> Filter<T>(List<T> items,Predicate<T> match)
        {
            //if (items == null)
            //{
            //    Console.WriteLine("Items should not be null");
            //}
            //if (match == null)
            //{
            //    Console.WriteLine("Match should not be null");
            //}
            //var result = new List<T>();
            //foreach(var item in items)
            //{
            //    if (match(item))
            //    {
            //        result.Add(item);
            //    }
            //}
            //return result;
            return items.Where(match.Invoke).ToList();
        }
    }
}
