using System.Data;
using Microsoft.VisualBasic;

public class Calc
{
    public bool Iseven(int n)
    {
        if (n % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void Main()
    {
        Calc cal=new Calc();
        string? choice="y";
        while(choice=="y")
        {
        Console.Write("Enter a number");
        int input=Convert.ToInt32(Console.ReadLine());
        bool result= cal.Iseven(input);
        Console.WriteLine($"The number {input} is even? {result}");
        Console.WriteLine("Do you want to continue? (y/n): ");
        choice=Console.ReadLine();
        }
        Console.WriteLine("Program is exited.");
    }
}