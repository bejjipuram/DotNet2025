using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_29_M1_Practice
{
    public class PasswordGenerator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the username: ");
            string username = Console.ReadLine() ?? "";
            if (!isValid(username))
            {
                Console.WriteLine(username + " is an invalid username");
                return;
            }
            string password = GeneratePassword(username);
            Console.WriteLine("Password: " + password);
        }
        public static bool isValid(string userinput)
        {
            //checking input Length
            if (userinput.Length != 8)
            {
                return false;
            }
            //checking first 4 characters are Uppercase or not
            for(int i = 0; i < 4; i++)
            {
                if (!(userinput[i]>='A' && userinput[i] <= 'Z'))
                {
                    return false;
                }
            }
            //4th character should be @ symbol
            if (userinput[4] != '@')
            {
                return false;
            }
            //from 5th character onwards 3 positions forward should be digits
            string last3 = userinput.Substring(5, 3);
            foreach(char cinput in last3)
            {
                if (!char.IsDigit(cinput))
                {
                    return false;
                }
            }
            //the digits should fall into the specified range only
            int courseId = int.Parse(last3);
            if(courseId<101 || courseId > 115)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Logic to generate the password
        /// </summary>
        /// <param name="userinput"></param>
        /// <returns></returns>
        public static string GeneratePassword(string userinput)
        {
            int sum = 0;
            for(int i = 0; i < 4; i++)
            {
                char lower = char.ToLower(userinput[i]);
                sum += (int)lower;
            }
            string last2 = userinput.Substring(6, 2);
            return "TECH_" + sum + last2;
        }
    }
}
