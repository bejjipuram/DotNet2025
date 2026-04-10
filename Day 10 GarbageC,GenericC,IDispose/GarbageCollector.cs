using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_10
{
    public class GarbageCollector
    {
        public static void Main()
        {
            var list = new List<byte[]>();
            for(int i = 0; i < 2000; i++)
            {
                list.Add(new byte[1024]);
            }
            Console.WriteLine("Allocated");
            Console.WriteLine("Total memory: " + GC.GetTotalMemory(forceFullCollection: false));
        }
    }
}
