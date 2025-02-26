using Microsoft.EntityFrameworkCore;
using Wolt_ConsoleApp.Data;
namespace Wolt_ConsoleApp.Functions.DataFunctions;
internal class RestaurantList
{
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }
    public static bool ShowRestaurantList()
    {
        using DataContext _context = new DataContext();
        var restaurants = _context.Restaurants
            .Include(a => a.Products)
            .ToList();
        if (!restaurants.Any())
        {
            Clear();
            Line();
            Console.WriteLine("No restaurants available.");
            Line();
            return false;
        }
        Clear();
        LineLong();
        foreach (var restaurant in restaurants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"ID: {restaurant.Id} - ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Name: {restaurant.RestaurantName} | ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Rating: {restaurant.Rating} | ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Balance: {restaurant.RestaurantBalance} | ");
            Console.ResetColor();
            Console.ForegroundColor = restaurant.DeliveryAvailable ? ConsoleColor.DarkGreen : ConsoleColor.Red;
            Console.WriteLine($"Delivery Available: {restaurant.DeliveryAvailable}");
            Console.ResetColor();
        }
        LineLong();
        return true;
    }
}
