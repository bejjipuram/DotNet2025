using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_20
{
    public class EcommerceShop
    {
        public string UserName { get; set; }
        public double WalletBalance { get; set; }
        public double TotalPurchaseAmount { get; set; }
    }

    public class InsufficientWalletBalanceException : Exception
    {
        public InsufficientWalletBalanceException(string message) : base(message) { }
    }

    public class EcomApp
    {
        public EcommerceShop MakePayment(string name, double balance, double amount)
        {
            if (balance < amount)
                throw new InsufficientWalletBalanceException("Insufficient balance in your digital wallet");

            // Create object and return it
            return new EcommerceShop
            {
                UserName = name,
                WalletBalance = balance - amount,          // remaining balance (realistic)
                TotalPurchaseAmount = amount
            };
        }

        public static void Main()
        {
            EcomApp p = new EcomApp();

            Console.Write("Enter user name: ");
            string name = Console.ReadLine();

            Console.Write("Enter wallet balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter purchase amount: ");
            double amount = double.Parse(Console.ReadLine());

            try
            {
                EcommerceShop shop = p.MakePayment(name, balance, amount);
                Console.WriteLine("Payment successful");
            }
            catch (InsufficientWalletBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
