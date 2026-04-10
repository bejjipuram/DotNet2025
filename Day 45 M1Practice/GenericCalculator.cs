using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class GenericCalculator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Apply(5,3,(a,b)=>a+b));
            Console.WriteLine(Apply(5, 3, (a, b) => a * b));
            Console.WriteLine(Apply("Hi", "Tech", (a, b) => a + " " + b));
        }
        public static T Apply<T>(T x,T y, Func<T,T,T> operation)
        {
            return operation(x, y);
        }
    }
}
