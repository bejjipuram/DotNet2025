using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_20
{
    public class CalculateNumbers
    {
        // In your template this is already provided.
        public static List<int> NumberList = new List<int>();

        public void AddNumbers(int numbers)
        {
            NumberList.Add(numbers);
        }

        public double GetGPAScored()
        {
            if (NumberList.Count == 0) return -1;

            // GPA formula in the question (credit point = 3)
            double sum = 0;
            foreach (int n in NumberList)
                sum += (n * 3);

            double gpa = sum / (NumberList.Count * 3);
            return gpa;
        }

        public char GetGradeScored(double gpa)
        {
            if (gpa < 5 || gpa > 10) return '\0';

            if (gpa == 10) return 'S';
            if (gpa >= 9) return 'A';
            if (gpa >= 8) return 'B';
            if (gpa >= 7) return 'C';
            if (gpa >= 6) return 'D';
            return 'E';
        }

        public static void Main()
        {
            CalculateNumbers p = new CalculateNumbers();

            Console.Write("Enter how many numbers: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                p.AddNumbers(int.Parse(Console.ReadLine()));
            }

            double gpa = p.GetGPAScored();
            if (gpa == -1)
            {
                Console.WriteLine("No Numbers Available");
                return;
            }

            Console.WriteLine($"GPA: {gpa}");
            char grade = p.GetGradeScored(gpa);

            if (grade == '\0')
                Console.WriteLine("Invalid GPA");
            else
                Console.WriteLine($"Grade: {grade}");
        }
    }
}