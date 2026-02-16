using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_32_M1Practice
{

    /// <summary>
    /// Custom exception for robot safety violations
    /// </summary>
    public class RobotSafetyException : Exception
    {
        public RobotSafetyException(string message) : base(message)
        {
            // Print error immediately
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// Calculates robot hazard risk
    /// </summary>
    public class RobotHazardAuditor
    {
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            // Validate arm precision
            if (armPrecision < 0.0 || armPrecision > 1.0)
                throw new RobotSafetyException("Error: Arm precision must be between 0.0 and 1.0");

            // Validate worker density
            if (workerDensity < 1 || workerDensity > 20)
                throw new RobotSafetyException("Error: Worker density must be between 1 and 20");

            double machineRiskFactor;

            // Decide risk factor based on machinery state
            if (machineryState == "Worn")
                machineRiskFactor = 1.3;
            else if (machineryState == "Faulty")
                machineRiskFactor = 2.0;
            else if (machineryState == "Critical")
                machineRiskFactor = 3.0;
            else
                throw new RobotSafetyException("Error: Invalid machinery state");

            // Hazard risk formula
            return ((1.0 - armPrecision) * 15) + (workerDensity * machineRiskFactor);
        }
    }

    /// <summary>
    /// Main class for Question 1
    /// </summary>
    public class RobotHazardMain
    {
        public static void Main()
        {
            try
            {
                Console.Write("Enter Arm Precision (0.0–1.0): ");
                double armPrecision = double.Parse(Console.ReadLine()!);

                Console.Write("Enter Worker Density (1–20): ");
                int workers = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Machinery State (Worn/Faulty/Critical): ");
                string state = Console.ReadLine()!;

                RobotHazardAuditor auditor = new RobotHazardAuditor();
                double risk = auditor.CalculateHazardRisk(armPrecision, workers, state);

                Console.WriteLine($"Robot Hazard Risk Score: {risk}");
            }
            catch (RobotSafetyException)
            {
                // Custom exception already handled
            }
        }
    }

}