using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_31_GenericsPractice
{
    public class Bike
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int PricePerDay { get; set; }
    }
    public class BikeUtility
    {
        public static SortedDictionary<int, Bike> bikedetails = new SortedDictionary<int, Bike>();
        public void AddBikeDetails(string model, string brand,int pricePerDay)
        {
            Bike bike = new Bike
            {
                Model = model,
                Brand = brand,
                PricePerDay = pricePerDay
            };
            int key = bikedetails.Count + 1;
            bikedetails.Add(key, bike);
        }
        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> groupedBikes = new SortedDictionary<string, List<Bike>>();
            foreach(var item in bikedetails.Values)
            {
                if (!groupedBikes.ContainsKey(item.Brand))
                {
                    groupedBikes[item.Brand] = new List<Bike>();
                }
                groupedBikes[item.Brand].Add(item);
            }
            return groupedBikes;
        }
    }
    public class BikeMain
    {
        public static void Main(string[] args)
        {
            BikeUtility utility=new BikeUtility();
            while (true)
            {
                Console.WriteLine("1. Add Bike Details.");
                Console.WriteLine("2. Group Bikes by Brand.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("Enter your choice");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the model: ");
                        string model = Console.ReadLine();
                        Console.WriteLine("Enter the brand: ");
                        string brand=Console.ReadLine();
                        Console.WriteLine("Enter the price per day: ");
                        int price=Convert.ToInt32(Console.ReadLine());
                        utility.AddBikeDetails(model, brand, price);
                        Console.WriteLine("Bike details added successfully.");
                        Console.WriteLine();
                        break;
                    case 2:
                        SortedDictionary<string, List<Bike>> result = utility.GroupBikesByBrand();
                        foreach(var brandgroup in result)
                        {
                            Console.WriteLine($"\nBrand: {brandgroup.Key}");
                            foreach (Bike bike in brandgroup.Value)
                            {
                                Console.WriteLine($"Model: {bike.Model}, Price Per Day: {bike.PricePerDay}");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
