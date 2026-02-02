using System;

/// <summary>
/// Represents a bank account with balance, deposit, and withdrawal functionality.
/// </summary>
public class Program
{
    /// <summary>
    /// Gets the current balance of the bank account.
    /// </summary>
    public decimal Balance { get; private set; }

    /// <summary>
    /// Initializes the bank account with an initial balance.
    /// </summary>
    /// <param name="initialBalance">Starting balance.</param>
    public Program(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    /// <summary>
    /// Deposits the specified amount into the account.
    /// </summary>
    /// <param name="amount">Amount to deposit.</param>
    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new Exception("Deposit amount cannot be negative");
        }

        Balance += amount;
    }

    /// <summary>
    /// Withdraws the specified amount from the account.
    /// </summary>
    /// <param name="amount">Amount to withdraw.</param>
    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new Exception("Insufficient funds.");
        }

        Balance -= amount;
    }
}
