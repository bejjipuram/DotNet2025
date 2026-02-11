using System;
using System.Collections.Generic;
using System.Linq;

namespace CAP2025.Day_39_M1Practice
{
    // ===============================
    // 1. Base Product Interface
    // ===============================
    public interface IProduct
    {
        int Id { get; }
        string Name { get; set; }
        decimal Price { get; set; }
        Category Category { get; }
    }

    public enum Category
    {
        Electronics,
        Clothing,
        Books,
        Groceries
    }

    // ===============================
    // 2. Generic Repository
    // ===============================
    public class ProductRepository<T> where T : class, IProduct
    {
        private readonly List<T> _products = new List<T>();

        public void AddProduct(T product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product name cannot be empty.");

            if (product.Price <= 0)
                throw new ArgumentException("Price must be positive.");

            if (_products.Any(p => p.Id == product.Id))
                throw new InvalidOperationException("Product ID must be unique.");

            _products.Add(product);
        }

        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _products.Where(predicate);
        }

        public decimal CalculateTotalValue()
        {
            return _products.Sum(p => p.Price);
        }

        public List<T> GetAll() => _products;
    }

    // ===============================
    // 3. Electronic Product
    // ===============================
    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;

        public int WarrantyMonths { get; set; }
        public string Brand { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Brand}) - ₹{Price}";
        }
    }

    // ===============================
    // 4. Clothing Product
    // ===============================
    public class ClothingProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Clothing;

        public string Size { get; set; }
    }

    // ===============================
    // 5. Discount Wrapper
    // ===============================
    public class DiscountedProduct<T> where T : IProduct
    {
        private readonly T _product;
        private readonly decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentException("Discount must be between 0 and 100.");

            _product = product;
            _discountPercentage = discountPercentage;
        }

        public decimal DiscountedPrice =>
            _product.Price * (1 - _discountPercentage / 100);

        public override string ToString()
        {
            return $"{_product.Name} | Original: ₹{_product.Price} | " +
                   $"Discount: {_discountPercentage}% | Final: ₹{DiscountedPrice}";
        }
    }

    // ===============================
    // 6. Inventory Manager
    // ===============================
    public class InventoryManager
    {
        public void ProcessProducts<T>(IEnumerable<T> products)
            where T : IProduct
        {
            Console.WriteLine("\n--- Product List ---");
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - ₹{p.Price}");

            var mostExpensive = products
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();

            if (mostExpensive != null)
                Console.WriteLine($"\nMost Expensive Product: {mostExpensive.Name}");

            Console.WriteLine("\n--- Grouped by Category ---");
            var grouped = products.GroupBy(p => p.Category);

            foreach (var group in grouped)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var item in group)
                    Console.WriteLine($"  {item.Name}");
            }

            Console.WriteLine("\n--- 10% Discount on Electronics > ₹500 ---");
            foreach (var p in products.Where(p =>
                         p.Category == Category.Electronics && p.Price > 500))
            {
                var discounted = new DiscountedProduct<IProduct>(p, 10);
                Console.WriteLine(discounted);
            }
        }

        public void UpdatePrices<T>(
            List<T> products,
            Func<T, decimal> priceAdjuster)
            where T : IProduct
        {
            foreach (var product in products)
            {
                try
                {
                    var newPrice = priceAdjuster(product);

                    if (newPrice <= 0)
                        throw new ArgumentException("Adjusted price must be positive.");

                    product.Price = newPrice;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Error updating {product.Name}: {ex.Message}");
                }
            }
        }
    }

    // ===============================
    // 7. TEST SCENARIO
    // ===============================
    public class Program
    {
        public static void Main()
        {
            var electronicsRepo = new ProductRepository<ElectronicProduct>();
            var clothingRepo = new ProductRepository<ClothingProduct>();

            // Add products
            electronicsRepo.AddProduct(new ElectronicProduct
            {
                Id = 1,
                Name = "Laptop",
                Price = 900,
                Brand = "Dell",
                WarrantyMonths = 24
            });

            electronicsRepo.AddProduct(new ElectronicProduct
            {
                Id = 2,
                Name = "Smartphone",
                Price = 1200,
                Brand = "Samsung",
                WarrantyMonths = 12
            });

            clothingRepo.AddProduct(new ClothingProduct
            {
                Id = 3,
                Name = "T-Shirt",
                Price = 500,
                Size = "M"
            });

            clothingRepo.AddProduct(new ClothingProduct
            {
                Id = 4,
                Name = "Jacket",
                Price = 1500,
                Size = "L"
            });

            electronicsRepo.AddProduct(new ElectronicProduct
            {
                Id = 5,
                Name = "Headphones",
                Price = 700,
                Brand = "Sony",
                WarrantyMonths = 18
            });

            // Find by Brand
            Console.WriteLine("\n--- Samsung Products ---");
            var samsung = electronicsRepo.FindProducts(p => p.Brand == "Samsung");
            foreach (var item in samsung)
                Console.WriteLine(item);

            // Total Value
            Console.WriteLine("\nTotal Electronics Value: ₹" +
                electronicsRepo.CalculateTotalValue());

            // Discount Example
            var discountExample = new DiscountedProduct<ElectronicProduct>(
                electronicsRepo.GetAll().First(), 15);

            Console.WriteLine("\nDiscount Example:");
            Console.WriteLine(discountExample);

            // Mixed Collection
            var mixed = new List<IProduct>();
            mixed.AddRange(electronicsRepo.GetAll());
            mixed.AddRange(clothingRepo.GetAll());

            var manager = new InventoryManager();
            manager.ProcessProducts(mixed);

            // Bulk Price Update (10% increase)
            manager.UpdatePrices(mixed.ToList(), p => p.Price * 1.10m);

            Console.WriteLine("\nAfter 10% Price Increase:");
            foreach (var p in mixed)
                Console.WriteLine($"{p.Name} - ₹{p.Price}");

            Console.WriteLine("\nTotal Inventory Value After Update: ₹" +
                mixed.Sum(p => p.Price));
        }
    }
}
