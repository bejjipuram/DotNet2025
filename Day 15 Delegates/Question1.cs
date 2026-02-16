using System;
using System.Collections.Generic;

namespace CAP2025.Day_16
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }

    public class PersonImplementation
    {
        // 1. Display Name and Address of all persons
        public static void GetName(IList<Person> persons)
        {
            foreach (Person p in persons)
            {
                Console.WriteLine("Name: " + p.Name + ", Address: " + p.Address);
            }
        }

        // 2. Calculate Average Age
        public static double Average(IList<Person> persons)
        {
            int sum = 0;
            foreach (Person p in persons)
            {
                sum += p.Age;
            }
            return (double)sum / persons.Count;
        }

        // 3. Find Maximum Age
        public static int Max(IList<Person> persons)
        {
            int maxAge = persons[0].Age;
            foreach (Person p in persons)
            {
                if (p.Age > maxAge)
                {
                    maxAge = p.Age;
                }
            }
            return maxAge;
        }
    }
    public class Program
    {
        public static void Main()
        {
            IList<Person> persons = new List<Person>()
            {
                new Person { Name = "Indra", Address = "Delhi", Age = 22 },
                new Person { Name = "Amit", Address = "Mumbai", Age = 25 },
                new Person { Name = "Ravi", Address = "Chennai", Age = 20 }
            };
            PersonImplementation.GetName(persons);
            Console.WriteLine("Average Age: " +
            PersonImplementation.Average(persons));

            Console.WriteLine("Maximum Age: " +
            PersonImplementation.Max(persons));
        }
    }
}
