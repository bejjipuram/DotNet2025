using System;
using System.Collections.Generic;

namespace CAP2025.Day_19
{
    public abstract class LinqStudent
    {
        public string Name { get; set; }
        public abstract string GetLevel();
    }

    public class UGStudent : LinqStudent
    {
        public override string GetLevel()
        {
            return "Undergraduate Student";
        }
    }

    public class PGStudent : LinqStudent
    {
        public override string GetLevel()
        {
            return "Postgraduate Student";
        }
    }

    public class MyGlobalType<T> where T : LinqStudent
    {
        private List<T> _myCollection;

        public MyGlobalType()
        {
            _myCollection = new List<T>();
        }

        public string GetDataType(T t)
        {
            return t.GetType().Name;
        }

        public void AddItem(T t)
        {
            _myCollection.Add(t);
        }

        public List<T> GetCollection()
        {
            return _myCollection;
        }

        public string ActBasedOnType(T t)
        {
            if (t is UGStudent)
            {
                return "UG Student";
            }
            else if (t is PGStudent)
            {
                return "PG Student";
            }
            else
            {
                return "Unknown Student Type";
            }
        }

    }

    public class CreateGenericMain
    {
        static void Main()
        {
            MyGlobalType<LinqStudent> myg = new MyGlobalType<LinqStudent>();

            UGStudent ug = new UGStudent { Name = "Arun" };
            PGStudent pg = new PGStudent { Name = "Bala" };

            myg.AddItem(ug);
            myg.AddItem(pg);

            Console.WriteLine(myg.GetDataType(ug));
            Console.WriteLine(myg.GetDataType(pg));

            Console.WriteLine(myg.ActBasedOnType(ug));
            Console.WriteLine(myg.ActBasedOnType(pg));

            foreach (var student in myg.GetCollection())
            {
                Console.WriteLine($"{student.Name} - {student.GetLevel()}");
            }

            Console.ReadLine();
        }
    }
}
