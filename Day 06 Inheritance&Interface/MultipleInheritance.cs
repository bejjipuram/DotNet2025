//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CAP2025.Day_6
//{
//    public class VegEater
//    {
//        public void VegEaterM()
//        {
//            Console.WriteLine("Veg only");
//        }
//    }
//    public interface IVegEater
//    {
//        public void EatVeg();
//        public void Taste();
//    }
//    public class NonVegEater
//    {
//        public void NonVegEaterM()
//        {
//            Console.WriteLine("Nonveg only");
//        }
//    }
//    public interface INonVegEater
//    {
//        public void EatNonVeg();
//        public void Taste();
//    }
//    public class Visitor : IVegEater, INonVegEater
//    {
//        public void EatVeg()
//        {
//            Console.WriteLine("Eats Veg");
//        }
//        public void EatNonVeg()
//        {
//            Console.WriteLine("Eats NonVeg");
//        }
//        public void IVegEaterTaste()
//        {
//            Console.WriteLine("Taste is good");
//        }
//        public void INonVegEaterTaste()
//        {
//            Console.WriteLine("Taste is good");
//        }

//    }
//    public class MultipleInheritanceMain
//    {
//        public static void Main(string[] args)
//        {
//            Visitor v = new Visitor();
//            v.EatNonVeg();
//            IVegEater IvEater = new Visitor();
//            //string IvEater = IVegEater.Taste();

//        }
//    }
//}
