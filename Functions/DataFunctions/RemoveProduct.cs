using Wolt_ConsoleApp.Data;
namespace Wolt_ConsoleApp.Functions.DataFunctions
{
    internal class RemoveProduct
    {
        public static void Clear() => Console.Clear();
        public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
        public static bool RemoveProductVoid()
        {
            DataContext _context = new DataContext();

            while (true)
            {
                Console.WriteLine("Enter Product Name To Remove:");
                string productName = Console.ReadLine()?.Trim();
                Clear();
                if (string.IsNullOrEmpty(productName))
                {
                    Line();
                    Console.WriteLine("Product name cannot be empty.");
                    Line();
                }
                else
                {
                    var product = _context.Products.FirstOrDefault(p => p.ProductName.ToLower() == productName.ToLower());
                    if (product == null)
                    {
                        Line();
                        Console.WriteLine($"Product '{productName}' was not found.");
                        Line();
                    }
                    else
                    {
                        _context.Products.Remove(product);
                        _context.SaveChanges();
                        Line();
                        Console.WriteLine($"Product '{productName}' has been removed successfully.");
                        Line();
                        return true;
                    }
                }
                Console.WriteLine("1. Try Again");
                Console.WriteLine("2. Main Menu");
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
}
