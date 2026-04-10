using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to perform basic or simple calculations by given inputs
    /// </summary>
    public class SimpleCalculator
    {
        public static void Main()
        {
            Console.Write("Enter two numbers: ");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.Write("Enter operator (+ - * /): ");
            char op = Console.ReadLine()[0];

            switch (op)
            {
                case '+': Console.WriteLine(a + b); break;
                case '-': Console.WriteLine(a - b); break;
                case '*': Console.WriteLine(a * b); break;
                case '/': Console.WriteLine(b != 0 ? a / b : "Division by zero"); break;
                default: Console.WriteLine("Invalid Operator"); break;
            }

        }
    }
}
