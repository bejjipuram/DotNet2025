using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(1000);
        account.Deposit(500);
        Assert.AreEqual(1500, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(1000);
        Assert.Throws<Exception>(() => account.Deposit(-100));
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(1000);
        account.Withdraw(400);
        Assert.AreEqual(600, account.Balance);
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(500);
        Assert.Throws<Exception>(() => account.Withdraw(800));
    }
}
