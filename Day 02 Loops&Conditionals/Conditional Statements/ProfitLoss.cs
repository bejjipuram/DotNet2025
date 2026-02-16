using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// Program to check the Profit and Loss Percentages
    /// </summary>
    public class ProfitLoss
    {
        public static void Main()
        {
            Console.Write("Enter Cost Price and Selling Price: ");
            double cp = double.Parse(Console.ReadLine());
            double sp = double.Parse(Console.ReadLine());

            if (sp > cp)
                Console.WriteLine("Profit % = " + ((sp - cp) / cp) * 100);
            else if (cp > sp)
                Console.WriteLine("Loss % = " + ((cp - sp) / cp) * 100);
            else
                Console.WriteLine("No Profit No Loss");


        }
    }
}
