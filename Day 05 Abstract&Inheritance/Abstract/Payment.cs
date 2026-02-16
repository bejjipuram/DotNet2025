//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Abstract
//{
//    /// <summary>
//    /// created an abstract class Payment and defined a constructor, a method and an abstract method
//    /// </summary>
//    public abstract class Payment
//    {
//        public decimal Amount { get; }
//        protected Payment(decimal amount)
//        {
//            Amount = amount;
//        }
//        public void PrintReceipt()
//        {
//            Console.WriteLine($"Receipt: Amount={Amount}");
//        }
//        public abstract void Pay();
//    }
//    class UpiPayment : Payment
//    {
//        public string UpiId { get; }
//        public UpiPayment(decimal amount, string upiId) : base(amount)
//        {
//            this.UpiId = upiId;
//        }
//        public override void Pay()
//        {
//            Console.WriteLine($"Paid {Amount} via UPI ({UpiId}).");
//        }
//    }
//    public class PaymentMain
//    {
//        public static void Main(string[] args)
//        {
//            Payment p = new UpiPayment(499.00m, "ittechgenie@upi");
//            p.Pay();
//            p.PrintReceipt();
//        }
//    }
//}
