using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_16
{
    public delegate void MyDelegate(string message);
    public class MultiCastDelegate
    {
        static void Email(string msg)
        {
            Console.Write("Enter Email to send: ");
            msg = Console.ReadLine();
            Console.WriteLine("Email sent: " + msg);
        }

        static void SMS(string msg)
        {
            Console.Write("Enter SMS to send: ");
            msg = Console.ReadLine();
            Console.WriteLine("SMS sent: " + msg);
        }

        static void Whatsapp(string msg)
        {
            Console.Write("Enter Whatsapp message to send: ");
            msg = Console.ReadLine();
            Console.WriteLine("Whatsapp message sent: "+msg);
           
        }

        static void Main()
        {
            //Console.Write("Enter message to send: ");
            //string userMessage = Console.ReadLine();
            MyDelegate val = Email;
            val += SMS;
            val += Whatsapp;
            val("");

        }
    }

}
