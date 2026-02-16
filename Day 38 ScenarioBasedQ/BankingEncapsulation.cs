using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_38_ScenarioBasedQ
{
    public class BankAccount
    {
        private double balance;

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount should be greater than Zero");
            }
            else
            {
                balance += amount;
            }

        }
        public void Withdraw(double amount)
        {
            if(!(amount>0 && amount <= balance))
            {
                Console.WriteLine("Amount must be greater than zero and less than the balance");
            }
            else
            {
                balance -= amount;
            }

        }
        public void Display()
        {
            Console.WriteLine($"Remaining balance: {balance:F2}");
        }
    }
    public class BankingEncapsulation
    {
        public static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.Deposit(500.50);
            account.Withdraw(500);
            account.Deposit(1000.05);
            account.Withdraw(500.05);
            account.Display();
        }
    }
}
