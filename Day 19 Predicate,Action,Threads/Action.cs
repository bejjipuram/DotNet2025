using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_19
{
    public class ActionClass
    {
        public static void Main(string[] args)
        {
            Action<string> logger = NewMethod();

            if (DateTime.Now.Hour < 12)
            {
                logger = GoodMoring();
            }
            else
            {
                logger = GoodDay();
            }

            logger("dd");




            logger = Method2();

            logger("Application Started"); // Invoking the Action

        }

        private static Action<string> GoodDay()
        {
            return message =>
            {
                Console.WriteLine("Good Morning");
            };
        }

        private static Action<string> NewMethod()
        {
            return message =>
            {
                Console.WriteLine($"[LOG]: {message} at {DateTime.Now}");
            };
        }

        private static Action<string> GoodDay(string str)
        {
            return message =>
            {
                Console.WriteLine($"Good Day to you");
            };
        }

        private static Action<string> GoodMoring()
        {
            return message =>
            {
                Console.WriteLine($"Good Morning");
            };
        }

        private static Action<string> Method1()
        {
            return message =>
            {
                Console.WriteLine($"[LOG]: {message.ToUpper()} at {DateTime.Now}");
            };
        }

        private static Action<string> Method2()
        {
            return message =>
            {
                Console.WriteLine($"Welcome to Programming");
            };
        }
    }
}
