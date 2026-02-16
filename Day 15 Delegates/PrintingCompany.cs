using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_16
{
    public delegate string PrintMessage(string message);
    public class PrintingCompany
    {
        public PrintMessage CustomerChoicePrintMessage { get; set; }
        public void Print(string message)
        {
            string messageToPrint = CustomerChoicePrintMessage(message);
            Console.Write(messageToPrint);
        }
    }
    public class PrintingCompanyMain
    {
        public static void Main(string[] args)
        {
            PrintingCompany print = new PrintingCompany();
            print.CustomerChoicePrintMessage = new PrintMessage(HappyDiwali);
            print.Print("Indra");
            Console.ReadLine();
        }
        private static string method1(string message)
        {
            return "Welcome to Delegate World----" + message;
        }
        private static string HappyNewYear(string message)
        {
            return "Happy New Year----" + message;
        }
        private static string HappyDiwali(string message)
        {
            return "Happy Diwali-----" + message;
        }
    }
}
