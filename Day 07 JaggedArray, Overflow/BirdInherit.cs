using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_7
{
    /// <summary>
    /// class bird that can sing
    /// </summary>
    public class Bird
    {
        public void Sing()
        {
            Console.WriteLine("Asian Koel can sing.");
        }
    }
    /// <summary>
    /// interface class for singing bird to inherit
    /// </summary>
    public interface IBird
    {
        public void Sing();
    }
    /// <summary>
    /// class bird2 that can dance
    /// </summary>
    public class Bird2
    {
        public void Dance()
        {
            Console.WriteLine("Peacock bird can dance.");
        }
    }
    /// <summary>
    /// interface class for dancing bird to inherit
    /// </summary>
    public interface IBird2
    {
        public void Dance();
    }
    /// <summary>
    /// a class ABird in which we are inheriting both the interaces(multiple inheritance) and implementing the functions from the interfaces
    /// </summary>
    public class ABird : IBird, IBird2
    {
        public void Sing()
        {
            Console.WriteLine("Koel can sing");
        }
        public void Dance()
        {
            Console.WriteLine("Peacock can dance");
        }
    }
    /// <summary>
    /// main class in which we are creating an object for child class and accessing the methods through it
    /// </summary>
    public class BirdInheritanceMain
    {
        public static void Main(string[] args)
        {
            ABird a = new ABird();
            //a.Dance();
            //a.Sing();
            IBird ia = new ABird();
            IBird2 ib = new ABird();
            ia.Sing();
            ib.Dance();
        }
    }
}
