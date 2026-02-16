using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_20
{
    public class EstimateDetails
    {
        public float ConstructionArea { get; set; }
        public float SiteArea { get; set; }
    }

    public class ConstructionEstimateException : Exception
    {
        public ConstructionEstimateException(string message) : base(message) { }
    }

    public class ConstructionExample
    {
        public EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea)
        {
            if (constructionArea <= siteArea)
            {
                return new EstimateDetails
                {
                    ConstructionArea = constructionArea,
                    SiteArea = siteArea
                };
            }

            throw new ConstructionEstimateException("Sorry your Construction Estimate is not approved");
        }

        public static void Main()
        {
            ConstructionExample p = new ConstructionExample();

            Console.Write("Enter Construction Area: ");
            float cArea = float.Parse(Console.ReadLine());

            Console.Write("Enter Site Area: ");
            float sArea = float.Parse(Console.ReadLine());

            try
            {
                EstimateDetails ed = p.ValidateConstructionEstimate(cArea, sArea);
                Console.WriteLine("Construction Estimate Approved");
            }
            catch (ConstructionEstimateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
