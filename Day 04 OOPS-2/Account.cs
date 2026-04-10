using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day4
{
    public class Account
    {
        public string AccountName { get; set; }
        public int AccountId { get; set; }
        public string GetAccountDetails()
        {
            return $"I am Base account. My Id is {AccountId}";
        }
    }
    public class SalesAccount : Account
    {
        public string GetSalesAccountDetails()
        {
            string info = string.Empty;
            info += base.GetAccountDetails();
            info += "I am from sales Derived class";
            return info;
        }
        public string SalesInfo { get; set; }
    }
    public class PurchaseAccount : Account
    {
        public string PurchaseInfo { get; set; }
    }
    public class AccountMain
    {
        public static void Main(string[] args)
        {
            Account account = new Account() { AccountId = 1, AccountName = "Account1" };
            string result = account.GetAccountDetails();
            SalesAccount sales = new SalesAccount() { AccountId = 1, AccountName = "Balu", SalesInfo = "" };
            var result1 = sales.GetSalesAccountDetails();
        }
    }
}
