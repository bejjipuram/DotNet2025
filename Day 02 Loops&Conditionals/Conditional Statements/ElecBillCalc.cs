using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to calculate the bill with variations in price based on the number of units that is consumed
    /// </summary>
    public class ElecBillCalc
    {
        public static void Main()
        {
            Console.Write("Enter units consumed: ");
            double units = double.Parse(Console.ReadLine());
            double bill;

            if (units <= 199)
                bill = units * 1.20;
            else if (units <= 399)
                bill = units * 1.50;
            else if (units <= 599)
                bill = units * 1.80;
            else
                bill = units * 2.00;

            if (bill > 400)
                bill += bill * 0.15;

            Console.WriteLine("Total Bill = " + bill);

        }
    }
}
