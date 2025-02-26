using FluentValidation;
using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Models;
using Wolt_ConsoleApp.Validators;
namespace Wolt_ConsoleApp.Functions.DataFunctions
{
    internal class EditProduct
    {
        public static DataContext _context = new DataContext();
        private static EditProductValidator _validator = new EditProductValidator();
        public static void Clear() => Console.Clear();
        public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
        public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }

        public static bool EditProductToDatabase()
        {
            while (true)
            {
                Clear();
                Console.WriteLine("Enter Product Name:");
                string productName = Console.ReadLine();
                if (string.IsNullOrEmpty(productName))
                {
                    ShowMessage("Product Name cannot be empty.");
                    if (!AskTryAgain()) return false;
                    continue;
                }
                var matchingProducts = _context.Products.Where(p => p.ProductName.ToLower() == productName.ToLower()).ToList();
                if (matchingProducts.Count == 0)
                {
                    ShowMessage("No product found with that name.");
                    ShowAllProducts();
                    if (!AskTryAgain()) return false;
                    continue;
                }
                Product selectedProduct;
                if (matchingProducts.Count == 1)
                {
                    selectedProduct = matchingProducts.First();
                }
                else
                {
                    Clear();
                    Line();
                    Console.WriteLine("Multiple products found with the same name");
                    Line();
                    foreach (var product in matchingProducts)
                    {
                        var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == product.RestaurantsId);
                        string restaurantName = restaurant?.RestaurantName ?? "Unknown Restaurant";
                        Console.WriteLine($"ID: {product.Id}, Name: {product.ProductName}, Restaurant: {restaurantName}");
                    }
                    Line();
                    Console.WriteLine("Enter Product ID:");
                    Line();
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            selectedProduct = matchingProducts.FirstOrDefault(p => p.Id == productId);
                            if (selectedProduct != null) break;
                        }
                        Console.WriteLine("Invalid Product ID. Try again:");
                    }
                }
                Clear();
                Line();
                Console.WriteLine($"Editing product: {selectedProduct.ProductName} (ID: {selectedProduct.Id})");
                Line();
                // Begin editing options
                Console.WriteLine("1. Edit Product Name");
                Console.WriteLine("2. Edit Product Price");
                Console.WriteLine("3. Edit Product Quantity");
                Console.WriteLine("4. Edit Product Availability");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    EditProductName(selectedProduct);
                }
                else if (choice == "2")
                {
                    EditProductPrice(selectedProduct);
                }
                else if (choice == "3")
                {
                    EditProductQuantity(selectedProduct);
                }
                else if (choice == "4")
                {
                    EditProductAvailability(selectedProduct);
                }
                else
                {
                    ShowMessage("Invalid choice.");
                    if (!AskTryAgain()) return true;
                }
                break;
            }
            return true;
        }
        // Edit Product Name with validation
        private static void EditProductName(Product selectedProduct)
        {
            while (true)
            {
                Clear();
                Console.WriteLine("Enter new Product Name:");
                string newName = Console.ReadLine();
                if (selectedProduct.ProductName == newName)
                {
                    Clear();
                    Line();
                    Console.WriteLine("The new product name is the same as the current one. Please enter a different name.");
                    Line();
                    if (!AskTryAgain()) return;
                    continue;
                }
                selectedProduct.ProductName = newName;
                var result = _validator.Validate(selectedProduct);
                if (!result.IsValid)
                {
                    Line();
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine($"Error: {failure.ErrorMessage}");
                    }
                    Line();
                    if (!AskTryAgain()) return;
                }
                else
                {
                    Clear();
                    LineLong();
                    Console.WriteLine($"New Product Name: {newName}!");
                    LineLong();
                    _context.SaveChanges();
                    break;
                }
            }
        }

        // Edit Product Price with validation
        private static void EditProductPrice(Product selectedProduct)
        {
            while (true)
            {
                Clear();
                Console.WriteLine("Enter new Product Price:");
                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                {
                    if (selectedProduct.ProductPrice == newPrice)
                    {
                        Clear();
                        Line();
                        Console.WriteLine("The new price is the same as the current one. Please enter a different price.");
                        Line();
                        if (!AskTryAgain()) return;
                        continue;
                    }
                    selectedProduct.ProductPrice = newPrice;
                    var result = _validator.Validate(selectedProduct);
                    if (!result.IsValid)
                    {
                        Line();
                        foreach (var failure in result.Errors)
                        {
                            Console.WriteLine($"Error: {failure.ErrorMessage}");
                        }
                        Line();
                        if (!AskTryAgain()) return;
                    }
                    else
                    {
                        Clear();
                        LineLong();          
                        Console.WriteLine($"New Product Price: {newPrice}!");
                        LineLong();
                        _context.SaveChanges();
                        break;
                    }
                }
                else
                {
                    Clear();
                    Line();
                    Console.WriteLine("Invalid price. Try again.");
                    Line();
                    if (!AskTryAgain()) return;
                }
            }
        }

        // Edit Product Quantity with validation
        private static void EditProductQuantity(Product selectedProduct)
        {
            while (true)
            {
                Clear();
                Console.WriteLine("Enter new Product Quantity:");
                if (int.TryParse(Console.ReadLine(), out int newQuantity))
                {
                    selectedProduct.ProductQuantity = newQuantity;
                    var result = _validator.Validate(selectedProduct);
                    if (!result.IsValid)
                    {
                        Line();
                        foreach (var failure in result.Errors)
                        {
                            Console.WriteLine($"Error: {failure.ErrorMessage}");
                        }
                        Line();
                        if (!AskTryAgain()) return;
                    }
                    else
                    {
                        Clear();
                        LineLong();
                        Console.WriteLine($"New Product Quantity: {newQuantity}!");
                        LineLong();
                        _context.SaveChanges();
                        break;
                    }
                }
                else
                {
                    Clear();
                    Line();
                    Console.WriteLine("Invalid quantity. Try again.");
                    Line();
                    if (!AskTryAgain()) return;
                }
            }
        }

        // Edit Product Availability with validation
        private static void EditProductAvailability(Product selectedProduct)
        {
            while (true)
            {
                Clear();
                Console.WriteLine("Enter New product availability? (yes/no):");
                string availability = Console.ReadLine().ToLower();
                if ((selectedProduct.IsAvailable && availability == "yes") || (!selectedProduct.IsAvailable && availability == "no"))
                {
                    Clear();
                    Line();
                    Console.WriteLine("The availability status is already the same. Please choose a different availability.");
                    Line();
                    if (!AskTryAgain()) return;
                    continue;
                }
                selectedProduct.IsAvailable = availability == "yes";
                var result = _validator.Validate(selectedProduct);
                if (!result.IsValid)
                {
                    Line();
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine($"Error: {failure.ErrorMessage}");
                    }
                    Line();
                    if (!AskTryAgain()) return;
                }
                else
                {
                    Clear();
                    LineLong();
                    Console.WriteLine($"New Product Availability: {availability}!");
                    LineLong();
                    _context.SaveChanges();
                    break;
                }
            }
        }

        private static void ShowMessage(string message)
        {
            Clear();
            Line();
            Console.WriteLine(message);
            Line();
        }
        public static void ShowAllProducts()
        {
            Console.WriteLine("Available Products:");
            LineLong();
            int count = 0;
            foreach (var product in _context.Products)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: {product.Id}");
                Console.ResetColor();
                Console.Write($", Product Name: {product.ProductName} |");
                count++;
                if (count % 3 == 0) Console.WriteLine();
            }
            if (_context.Products.Count() % 3 != 0) Console.WriteLine();
            LineLong();
        }

        public static bool AskTryAgain()
        {
            Console.WriteLine("1. Try Again");
            Console.WriteLine("2. Main Menu");
            string choice = Console.ReadLine();
            Clear();
            return choice == "1";
        }
    }
}
