using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CAP2025.Day_19
{
    public class FileMan1Main
    {
        public static void Main(string[] args)
        {
            string[] lines = { "First Line", "Second Line", "Third Line" };
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Myfile.txt")))
            {
                foreach(string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }
            Console.WriteLine("File written successful at ");
        }
    }
}
