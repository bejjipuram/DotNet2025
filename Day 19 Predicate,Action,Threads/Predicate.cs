using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CAP2025.Day_19
{
    public class Predicate
    {
        //public Predicate(int a)
        //{
        //    Predicate<int> isEven = number => number % 2 == 0;
        //    bool check = isEven(a);
        //    Console.WriteLine($"{a} is EVEN? " + check);
        //}
        public void ActionA()
        {
            Action<string> logger = message =>
            {
                Console.WriteLine($"[LOG]: {message} at {DateTime.Now}");
            };
            logger = message =>
            {
                Console.WriteLine($"[LOG]: {message.ToUpper()} at {DateTime.Now}");
            };
            logger("Application Started");
        }
        public void ActionB(int a, int b)
        {

            Action<int> update = message =>
            {
                Console.WriteLine($"{message} is updated");
            };
            update((a+b)*2);
        }
        public void FuncA(int a, int b)
        {
            Func<int, int, string> multiplyResult = (x, y) =>
            {
                return $"{x} times {y} is {x * y}";
            };
            string resultText = multiplyResult(a, b);
            Console.WriteLine(resultText);
        }
    }
    public class PredicateMain
    {
        public static void Main(string[] args)
        {
            Predicate pre = new Predicate();
            pre.ActionB(10,3);
            pre.ActionA();
            pre.FuncA(10, 5);
        }
    }
}
