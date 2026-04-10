using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class NotificationPipeLine
    {
        public delegate void Notifier(string message);
        public static void Main(string[] args)
        {
            Notifier pipeline = BuildPipeline();
            pipeline("Order Created");
        }
        public static Notifier BuildPipeline()
        {
            Notifier notification = null;
            notification += SendEmail;
            notification += SendSMS;
            notification += WriteLog;
            return notification;
        }
        private static void SendEmail(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
        private static void SendSMS(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }
        private static void WriteLog(string message)
        {
            Console.WriteLine($"Log: {message} at {DateTime.Now}");
        }

    }
}
