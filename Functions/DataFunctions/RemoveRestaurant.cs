using Wolt_ConsoleApp.Data;
namespace Wolt_ConsoleApp.Functions.DataFunctions;
internal class RemoveRestaurant
{
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static bool RemoveRestaurantVoid()
    {
        DataContext _context = new DataContext();
        while (true)
        {
            Console.WriteLine("Enter Restaurant Name To Remove:");
            string RestaurantName = Console.ReadLine()?.Trim();
            Clear();
            if (string.IsNullOrEmpty(RestaurantName))
            {
                Line();
                Console.WriteLine("Restaurant name cannot be empty.");
                Line();
            }
            else
            {
                var Restaurant = _context.Restaurants.FirstOrDefault(p => p.RestaurantName.ToLower() == RestaurantName.ToLower());
                if (Restaurant == null)
                {
                    Line();
                    Console.WriteLine($"Product '{RestaurantName}' was not found.");
                    Line();
                }
                else
                {
                    _context.Restaurants.Remove(Restaurant);
                    _context.SaveChanges();
                    Line();
                    Console.WriteLine($"Restaurant '{RestaurantName}' has been removed successfully.");
                    Line();
                    return true;
                }
            }
            Console.WriteLine("1. Try Again");
            Console.WriteLine("2. Data Management Menu");
            string choice = Console.ReadLine()?.Trim();
            Clear();
            if (choice == "1")
            { }
            else if (choice == "2")
            {
                return false;
            }
            else
            {
                Line();
                Console.WriteLine("Invalid choice.");
                Line();
                return false;
            }
        }
    }
}
