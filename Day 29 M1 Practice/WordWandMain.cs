using System;

namespace CAP2025.Day_29_M1_Practice
{
    public class WordWandMain
    {
        static void Main()
        {
            Console.WriteLine("Enter the sentence");

            string sentence = Console.ReadLine() ?? string.Empty;

            // Step 1: Validate
            if (!IsValid(sentence))
            {
                Console.WriteLine("Invalid Sentence");
                return;
            }

            // Step 2: Split words
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int count = words.Length;

            Console.WriteLine("Word Count: " + count);

            // Step 3: Check odd / even
            if (count % 2 == 0)
            {
                // Even → Reverse word order
                ReverseWords(words);
            }
            else
            {
                // Odd → Reverse letters of each word
                ReverseLetters(words);
            }
        }

        // Check if sentence has only letters and spaces
        static bool IsValid(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        // Reverse word order
        static void ReverseWords(string[] words)
        {
            int left = 0;
            int right = words.Length - 1;
            while (left < right)
            {
                string temp = words[left];
                words[left] = words[right];
                words[right] = temp;
                left++;
                right--;
            }
            Print(words);
        }

        // Reverse letters in each word
        static void ReverseLetters(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                char[] arr = words[i].ToCharArray();
                int left = 0;
                int right = arr.Length - 1;
                while (left < right)
                {
                    char temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;

                }
                words[i] = new string(arr);
            }

            Print(words);
        }

        static void Print(string[] words)
        {
            string result = "";
            for(int i = 0; i < words.Length; i++)
            {
                result += words[i];
                if (i < words.Length - 1)
                {
                    result += " ";
                }
            }
            Console.WriteLine(result);
        }
    }
}
