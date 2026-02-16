using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to check whether the candidate is eligible for the admission based on the Marks criteria
    /// </summary>
    public class AdmissionEligibilty
    {
        public static void Main()
        {
            Console.Write("Enter Math, Physics, Chemistry marks: ");
            int m = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int total = m + p + c;

            if (m >= 65 && p >= 55 && c >= 50 && (total >= 180 || (m + p) >= 140))
                Console.WriteLine("Eligible for Admission");
            else
                Console.WriteLine("Not Eligible");
        }
    }
}
