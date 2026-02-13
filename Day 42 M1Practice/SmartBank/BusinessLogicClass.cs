using System;
using System.Collections.Generic;


namespace CAP2025.Day_42_M1Practice.SmartBank
{
    public class CreditRiskProcessor
    {
        // Validation Method
        public static bool ValidateCustomerDetails(
            int age,
            string employmentType,
            double monthlyIncome,
            double dues,
            int creditScore,
            int defaults)
        {
            if (age < 21 || age > 65)
            {
                Console.WriteLine("Invalid age");
            }

            if (employmentType != "Salaried" && employmentType != "Self-Employed")
            {
                Console.WriteLine("Invalid Employement Type");
            }

            if (monthlyIncome < 20000)
            {
                Console.WriteLine("Invalid monthly income");
            }

            if (dues < 0)
            {
                Console.WriteLine("Invalid credit dues");
            }

            if (creditScore < 300 || creditScore > 900)
            {
                Console.WriteLine("Invalid credit score");
            }

            if (defaults < 0)
            {
                Console.WriteLine("Invalid default count");
            }

            return true;
        }

        // Credit Limit Calculation
        public static double CalculateCreditLimit(
            double monthlyIncome,
            double dues,
            int creditScore,
            int defaults)
        {
            double debtRatio = dues / (monthlyIncome * 12);

            // High Risk
            if (creditScore < 600 || defaults >= 3 || debtRatio > 0.4)
            {
                return 50000;
            }

            // Low Risk
            if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            {
                return 300000;
            }

            // Medium Risk
            return 150000;
        }
    }
}
