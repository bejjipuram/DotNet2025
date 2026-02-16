using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_25_Attributes
{
    public class Calculate
    {
        [Obsolete("Use the Add(int, int) method instead.")]
        public int OldAdd(int a,int b)
        {
            return a + b;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    public class AttributeMain
    {
        public static void Main(string[] args)
        {
            Calculate calc = new Calculate();
            calc.OldAdd(3, 4);
            calc.Add(5, 6);
            Console.WriteLine("Program is success");
        }
    }
}
