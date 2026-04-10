using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class GenericSum
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Sum(new List<int> { 1,2,3,4}));
            Console.WriteLine(Sum(new List<double> { 1.5, 1.9, 1.1 }));
        }
        public static T Sum<T>(IEnumerable<T> items) where T : struct
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            dynamic total = default(T);
            foreach (var item in items)
            {
                total += (dynamic)item;
                

            }
            return (T)total;
        }
    }
}
