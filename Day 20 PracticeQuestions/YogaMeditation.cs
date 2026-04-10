using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_20
{
    public class MeditationCenter
    {
        public int MemberId { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }     // Kgs (as per question text)
        public double Height { get; set; }     // Inches (as per question text)
        public string Goal { get; set; }       // "Weight Loss" or "Weight Gain"
        public double BMI { get; set; }
    }

    public class YogaMeditation
    {
        // In your template this is already provided.
        public static ArrayList memberList = new ArrayList();

        public void AddYogaMember(int memberId, int age, double weight, double height, string goal)
        {
            MeditationCenter m = new MeditationCenter
            {
                MemberId = memberId,
                Age = age,
                Weight = weight,
                Height = height,
                Goal = goal,
                BMI = 0
            };

            memberList.Add(m);
        }

        public double CalculateBMI(int memberId)
        {
            foreach (MeditationCenter m in memberList)
            {
                if (m.MemberId == memberId)
                {
                    double bmi = m.Weight / (m.Height * m.Height);

                    // 2 decimal places using Math.Floor (truncate)
                    bmi = Math.Floor(bmi * 100) / 100;

                    m.BMI = bmi;
                    return bmi;
                }
            }

            return 0; // not present
        }

        public int CalculateYogaFee(int memberId)
        {
            foreach (MeditationCenter m in memberList)
            {
                if (m.MemberId == memberId)
                {
                    // Ensure BMI is calculated
                    if (m.BMI == 0)
                        CalculateBMI(memberId);

                    if (m.Goal == "Weight Gain")
                        return 2500;

                    if (m.Goal == "Weight Loss")
                    {
                        if (m.BMI >= 25 && m.BMI < 30) return 2000;
                        if (m.BMI >= 30 && m.BMI < 35) return 2500;
                        if (m.BMI >= 35) return 3000;
                    }

                    return 0; // for any other goal
                }
            }

            return 0; // member not found
        }

        public static void Main()
        {
            YogaMeditation p = new YogaMeditation();

            // Add a few sample members
            p.AddYogaMember(101, 26, 78, 68, "Weight Loss");
            p.AddYogaMember(102, 30, 55, 64, "Weight Gain");

            Console.Write("Enter MemberId to calculate BMI: ");
            int id = int.Parse(Console.ReadLine());

            double bmi = p.CalculateBMI(id);
            if (bmi == 0)
            {
                Console.WriteLine($"MemberId '{id}' is not present");
                return;
            }

            Console.WriteLine($"BMI: {bmi}");

            int fee = p.CalculateYogaFee(id);
            Console.WriteLine($"Yoga Fee: {fee}");
        }
    }
}
