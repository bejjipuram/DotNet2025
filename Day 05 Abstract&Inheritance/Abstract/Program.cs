//using System;
//public abstract class Employee
//{
//    public string Name { get; set; }
//    public double Salary { get; set; }
//    public abstract double CalcTax();
//    public void Display()
//    {
//        Console.WriteLine("Employee Name: " + Name);
//        Console.WriteLine("Income: " + Salary);
//    }
//}
//public class IndianE : Employee
//{
//    public override double CalcTax()
//    {
//        if (Salary <= 1000000)
//        {
//            return Salary * 0.1;
//        }
//        else if (Salary <= 2000000)
//        {
//            return Salary * 0.2;
//        }
//        else
//        {
//            return Salary * 0.4;
//        }
//    }
//}
//public class USE : Employee
//{
//    public override double CalcTax()
//    {
//        if (Salary <= 1000000)
//        {
//            return Salary * 0.2;
//        }
//        else if (Salary <= 3000000)
//        {
//            return Salary * 0.3;
//        }
//        else
//        {
//            return Salary * 0.4;
//        }
//    }
//}
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Employee emp = new IndianE();
//        emp.Name = "Bejjipuram Indra Kumar";
//        emp.Salary = 2000000.657;
//        Employee emp2 = new USE();
//        emp2.Name = "Sony Priyanka";
//        emp2.Salary = 2000000.8975;
//        Console.WriteLine("Indian Employee Tax: " + emp.CalcTax());
//        Console.WriteLine("US Employee Tax: " + emp2.CalcTax());
//    }
//}