using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Functions.ProductFunctions;
namespace Wolt_ConsoleApp.Functions;
internal class ProductManagement
{
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
    public static int LineLong()
    {
        int length = 100;
        string dashLine = new string('-', length);
        Console.WriteLine(dashLine);
        return length;
    }
    public static void ProductManagementVoid()
    {
        DataContext _context = new DataContext();
        bool MainMenu = false;
        while (!MainMenu) {
            Clear();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Edit Product");
            Console.WriteLine("3. Remove Product");
            Console.WriteLine("4. Product List");
            Console.WriteLine("5. Main Menu");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Clear();
                MainMenu = true;
                AddProduct.AddProductToRestaurant();
            }
            else if (choice == "2") {
                Clear();
                MainMenu = true;
            }
            else if (choice == "3")
            {
                Clear();
                MainMenu = true;
            }
            else if (choice == "4")
            {
                Clear();
                MainMenu = true;
            }
            else if (choice == "5")
            {
                Clear();
                MainMenu = true;
            }
            else
            {
                Clear();
                Line();
                Console.WriteLine("Invalid Choice!");
                Line();
                MainMenu = true; 
            }
        }
    }
}
