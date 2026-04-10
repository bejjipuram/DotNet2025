using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class GenericRepository
    {
        public static void Main(string[] args)
        {
            var intRepo = new SimpleRepo<int>();
            intRepo.Add(10);
            intRepo.Add(20);
            Console.WriteLine(string.Join(",", intRepo.GetAll()));
            var nameRepo = new SimpleRepo<string>();
            nameRepo.Add("Gopala");
            nameRepo.Add("Krishna");
            Console.WriteLine(string.Join(",", nameRepo.GetAll()));
        }

    }
    public class SimpleRepo<T>
    {
        private readonly List<T> items = new();
        public void Add(T item)
        {
            items.Add(item);
        }
        public IReadOnlyList<T> GetAll()
        {
            return items;
        }
    }
}
