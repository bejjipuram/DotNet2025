using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025
{
    /// <summary>
    /// program to do the ATM operations
    /// </summary>
    public class ATMWithdrawal
    {
        public static void Main()
        {
            Console.Write("Card inserted? (1-Yes, 0-No): ");
            int card = int.Parse(Console.ReadLine());

            if (card == 1)
            {
                Console.Write("Enter PIN (1234): ");
                int pin = int.Parse(Console.ReadLine());

                if (pin == 1234)
                {
                    Console.Write("Enter balance: ");
                    int bal = int.Parse(Console.ReadLine());

                    Console.Write("Enter withdrawal amount: ");
                    int amt = int.Parse(Console.ReadLine());

                    if (bal >= amt)
                        Console.WriteLine("Withdrawal Successful");
                    else
                        Console.WriteLine("Insufficient Balance");
                }
                else
                    Console.WriteLine("Invalid PIN");
            }
            else
                Console.WriteLine("Insert Card");

        }
    }
}
