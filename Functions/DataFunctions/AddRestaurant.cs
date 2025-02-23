using FluentValidation;
using FluentValidation.Results;
using Wolt_ConsoleApp.Models;
using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Validators;
using System.Linq.Expressions;

namespace Wolt_ConsoleApp.Functions.DataFunctions
{
    internal class AddRestaurant
    {
        private static readonly DataContext _context = new DataContext();
        private static readonly AddRestaurantValidator _validator = new AddRestaurantValidator();
        public static void Clear() => Console.Clear();
        public static void Line() => Console.WriteLine(new string('-', 60));
        public static void InvalidChoice() { Clear(); Line(); Console.WriteLine("Invalid choice!"); Line(); }
        public static bool AddRestaurantToDatabase()
        {
            while (true)
            {
                Clear();
                // Restaurant Name // Restaurant Name
                string restaurantName;
                while (true)
                {
                    Clear();
                    Console.WriteLine("Enter Restaurant Name:");
                    restaurantName = Console.ReadLine()?.Trim();
                    Clear();
                    if (ValidateInput(new Restaurants { RestaurantName = restaurantName }, x => x.RestaurantName))
                        break;
                    if (!HandleRetry()) return false; 
                }
                if (_context.Restaurants.Any(r => r.RestaurantName == restaurantName))
                {
                    Line();
                    Console.WriteLine("Restaurant Name already exists.");
                    Line();
                    if (!HandleRetry()) return false;
                    continue;
                }
                // Restaurant Name // Restaurant Name
                // Restaurant Balance // Restaurant Balance
                decimal restaurantBalance;
                while (true)
                {
                    Clear();
                    Console.WriteLine("Enter Restaurant Balance:");
                    string input = Console.ReadLine()?.Trim();
                    if (decimal.TryParse(input, out restaurantBalance) &&
                        ValidateInput(new Restaurants { RestaurantBalance = restaurantBalance }, x => x.RestaurantBalance))
                        break;
                    Line();
                    Console.WriteLine("Invalid input! Please enter number.");
                    Line();
                    if (!HandleRetry()) return false;
                }
                // Restaurant Balance // Restaurant Balance
                // Rating // Rating // Rating  // Rating
                double rating;
                while (true)
                {
                    Clear();
                    Console.WriteLine("Enter Rating:");
                    string input = Console.ReadLine()?.Trim();
                    if (double.TryParse(input, out rating) &&
                        ValidateInput(new Restaurants { Rating = rating }, x => x.Rating))
                        break;
                    Line();
                    Console.WriteLine("Invalid input. Please enter a valid rating.");
                    Line();
                    if (!HandleRetry()) return false;
                }
                // Rating // Rating // Rating  // Rating
                // Delivery Availability   // Delivery Availability
                bool deliveryAvailable;
                while (true)
                {
                    Clear();
                    Console.WriteLine("Is Delivery Available? (Y/N)");
                    string delivery = Console.ReadLine()?.Trim().ToUpper();
                    if (delivery == "Y" || delivery == "N")
                    {
                        deliveryAvailable = delivery == "Y";
                        break;
                    }
                    Line();
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                    Line();
                    if (!HandleRetry()) return false;
                }
                // Delivery Availability   // Delivery Availability
                // Add to database   // Add to database   // Add to database
                _context.Restaurants.Add(new Restaurants
                {
                    RestaurantName = restaurantName,
                    RestaurantBalance = restaurantBalance,
                    Rating = rating,
                    DeliveryAvailable = deliveryAvailable
                });
                _context.SaveChanges();
                // Add to database   // Add to database   // Add to database
                Clear();
                Line();
                Console.WriteLine("Restaurant Added Successfully!");
                Line();
                return true; 
            }
        }
        private static bool ValidateInput<T>(Restaurants restaurant, Expression<Func<Restaurants, T>> property)
        {
            string propertyName = ((MemberExpression)property.Body).Member.Name;
            ValidationResult result = _validator.Validate(restaurant, options => options.IncludeProperties(propertyName));
            if (result.IsValid) return true;
            Clear();
            Line();
            Console.WriteLine(result.Errors[0].ErrorMessage);
            Line();
            return false;
        }
        private static bool HandleRetry()
        {
            while (true)
            {
                Console.WriteLine("1. Try Again");
                Console.WriteLine("2. Cancel");
                string choice = Console.ReadLine()?.Trim();
                Clear();
                if (choice == "1") return true;
                if (choice == "2") return false;
                InvalidChoice();
            }
        }
    }
}
