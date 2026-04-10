using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_33_Exception_FileHandlingPractice
{
    public class BankAccount
    {
        public static void Main(string[] args)
        {
            int balance = 10000;
            try
            {
                Console.Write("Enter the withdrawal amount: ");
                int amount = int.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be greater than zero..");
                }
                if (amount > balance)
                {
                    throw new ArgumentException("Insufficient balance.");
                }
                balance -= amount;
                Console.WriteLine($"Withdrawal successful. Remaining balance: {balance}");

            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid numeric amount..");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected Error: "+ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction Completed..");
            }
            
        }
    }
}
