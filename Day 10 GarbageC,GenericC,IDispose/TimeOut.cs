using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CAP2025.Day_10
{
    public class TimeOut
    {
        public static void Main(string[] args)
        {
   
            string input = "Error: TIMEOUT while Calling API";
            string pattern = @"timeout";

            //input=Console.ReadLine();

            //Thread.Sleep(200);
            var rx = new Regex(
                pattern,
                RegexOptions.IgnoreCase,
                TimeSpan.FromMicroseconds(15000));
            Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");

            //Console.Read();
        }
    }
}
