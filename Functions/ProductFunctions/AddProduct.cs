using FluentValidation;
using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Models;
using Wolt_ConsoleApp.Validators;

namespace Wolt_ConsoleApp.Functions.ProductFunctions
{
    internal class AddProduct
    {
        public static DataContext _context = new DataContext();
        public static AddProductValidator _validator = new AddProductValidator();
        public static void Clear()
        {
            Console.Clear();
        }
        public static int Line()
        {
            int length = 60;
            string dashLine = new string('-', length);
            Console.WriteLine(dashLine);
            return length;
        }
        public static void InvalidChoice()
        {
            Clear();
            Line();
            Console.WriteLine("Invalid choice");
            Line();
        }
        public static void AddProductToRestaurant()
        {
            bool IsProductAdded = false;
            while (!IsProductAdded)
            {
                string productName = "";
                decimal productPrice = 0;
                bool isAvailable = false;
                int productQuantity = 0;
                int restaurantId = 0;
                //  Validate Product Name //  Validate Product Name
                bool IsValidName = false;
                while (!IsValidName)
                {
                    Clear();
                    Console.WriteLine("Enter Product Name:");
                    productName = Console.ReadLine();
                    Clear();
                    var validationResult = _validator.Validate(new Product { ProductName = productName }, options => options.IncludeProperties(x => x.ProductName));
                    if (!validationResult.IsValid)
                    {
                        Line();
                        Console.WriteLine(validationResult.Errors[0].ErrorMessage);
                        Line();
                        if (!HandleRetry()) return;
                        continue;
                    }
                    if (_context.Products.Any(p => p.ProductName == productName))
                    {
                        Line();
                        Console.WriteLine("Product Name already exists.");
                        Line();
                        if (!HandleRetry()) return;
                        continue;
                    }
                    IsValidName = true;
                }
                // Validate Product Price  // Validate Product Price
                bool IsValidPrice = false;
                while (!IsValidPrice)
                {
                    Clear();
                    Console.WriteLine("Enter Product Price:");
                    if (!decimal.TryParse(Console.ReadLine(), out productPrice))
                    {
                        Clear();
                        Line();
                        Console.WriteLine("Invalid price. Please enter a number.");
                        Line();
                        if (!HandleRetry()) return;
                        continue;
                    }
                    var validationResult = _validator.Validate(new Product { ProductPrice = productPrice }, options => options.IncludeProperties(x => x.ProductPrice));
                    if (!validationResult.IsValid)
                    {
                        Clear();
                        Line();
                        Console.WriteLine(validationResult.Errors[0].ErrorMessage);
                        Line();
                        if (!HandleRetry()) return;
                        continue;
                    }
                    IsValidPrice = true;
                }
                // Validate Product Availability // Validate Product Availability
                bool IsValidAvailable = false;
                while (!IsValidAvailable)
                {
                    Clear();
                    Console.WriteLine("Is Available? (Y/N):");
                    string input = Console.ReadLine().Trim().ToUpper();
                    if (input == "Y")
                    {
                        isAvailable = true;
                        IsValidAvailable = true;
                    }
                    else if (input == "N")
                    {
                        isAvailable = false;
                        IsValidAvailable = true;
                    }
                    else
                    {
                        Clear();
                        Line();
                        Console.WriteLine("Invalid input. Enter Y or N.");
                        Line();
                        if (!HandleRetry()) return;
                    }
                }
                // Validate Product Quantity  // Validate Product Quantity
                bool IsValidQuantity = false;
                while (!IsValidQuantity)
                {
                    Clear();
                    Console.WriteLine("Enter Product Quantity:");
                    if (!int.TryParse(Console.ReadLine(), out productQuantity))
                    {
                        Clear();
                        Line();
                        Console.WriteLine("Invalid quantity. Please enter a number.");
                        Line();
                        if (!HandleRetry()) return;
                        continue;
                    }
                    var validationResult = _validator.Validate(new Product { ProductQuantity = productQuantity }, options => options.IncludeProperties(x => x.ProductQuantity));
                    if (!validationResult.IsValid)
                    {
                        Clear();
                        Line();
                        Console.WriteLine(validationResult.Errors[0].ErrorMessage);
                        Line();
                        if (!HandleRetry()) return;
                        continue;
                    }
                    IsValidQuantity = true;
                }
                // Validate Restaurant ID   // Validate Restaurant ID
                bool IsValidRestaurant = false;
                while (!IsValidRestaurant)
                {
                    Clear();
                    Console.WriteLine("Available Restaurants:");
                    foreach (var restaurant in _context.Restaurants)
                    {
                        Line();
                        Console.WriteLine($"ID: {restaurant.Id} - Name: {restaurant.RestaurantName}");                  
                    }
                    Line();
                    Console.WriteLine("Enter Restaurant ID:");
                    if (!int.TryParse(Console.ReadLine(), out restaurantId))
                    {
                        Clear();
                        Line();
                        Console.WriteLine("Invalid ID. Enter a number.");
                        Line();
                        if (!HandleRetry()) return;
                        continue;
                    }
                    if (!_context.Restaurants.Any(r => r.Id == restaurantId))
                    {
                        Clear();
                        Line();
                        Console.WriteLine("Restaurant ID not found.");
                        Line();
                        if (!HandleRetry()) return;
                        continue;
                    }
                    IsValidRestaurant = true;
                }
                /// Add Product  /// Add Product /// Add Product
                var newProduct = new Product
                {
                    ProductName = productName,
                    ProductPrice = productPrice,
                    IsAvailable = isAvailable,
                    ProductQuantity = productQuantity,
                    RestaurantsId = restaurantId
                };
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("Product Added successfully!");
                Line();
                IsProductAdded = true;
            }
        }
        private static bool HandleRetry()
        {
            Console.WriteLine("1. Try Again");
            Console.WriteLine("2. Cancel");
            string choice = Console.ReadLine();
            Clear();
            if (choice == "1") return true;
            if (choice == "2") return false;
            InvalidChoice();
            return false;
        }
    }
}
