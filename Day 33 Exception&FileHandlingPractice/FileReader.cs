using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CAP2025.Day_33_Exception_FileHandlingPractice
{
    public class FileReader
    {
        public static void Main(string[] args)
        {
            string filePath = @"D:\\OneDrive\\Documents\\Myfil2e.txt";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("Content is: ");
                    Console.WriteLine(content);
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
