using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_10
{
    public static class Palindrome
    {
        public static void PalindromeCheck(this string inp)
        {
            string str = inp.ToLower();
            #region using Array
            //char[] chars = str.ToCharArray();
            //Array.Reverse(chars);
            //string revString = new string(chars);
            //if (str == revString)
            //{
            //    Console.WriteLine(inp + " is a Palindrome");
            //}
            //else
            //{
            //    Console.WriteLine(inp + " is not a Palindrome");
            //}
            #endregion
            bool val = true;
            int left = 0;
            int right = str.Length-1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    val = false;
                    break;
                }
                left++;
                right--;
            }
            if ((val))
            {
                Console.WriteLine(inp + " is a Palindrome");
            }
            else
            {
                Console.WriteLine(inp + " is not a Palindrome");
            }
        }
    }
    public class PalindromeMain
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the word to check for Palindrome: ");
            string inp = Console.ReadLine();
            inp.PalindromeCheck();
        }
    }
}
