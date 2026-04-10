using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class GenericSwap
    {
        public static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            Swap(ref a, ref b);
            Console.WriteLine($"a={a}, b={b}");
            string x = "Gopi";
            string y = "Suresh";
            Swap(ref x, ref y);
            Console.WriteLine($"x={x}, y={y}");

        }
        public static void Swap<T>(ref T left,ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
    }
}
