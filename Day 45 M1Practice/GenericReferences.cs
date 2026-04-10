using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class GenericReferences
    {
        public static void Main(string[] args)
        {
            var cache = new RefCache<string>();
            cache.Set(null);
            Console.WriteLine(cache.GetOrDefault("NA"));
            cache.Set("Hello");
            Console.WriteLine(cache.GetOrDefault("NA"));
            //var wrong=new RefCache<int>();
        }
    }
    public class RefCache<T> where T : class
    {
        private T? values;
        public void Set(T? value)
        {
            values = value;
        }
        public T GetOrDefault(T defaultValue)
        {
            return values ?? defaultValue;
        }
    }
}
