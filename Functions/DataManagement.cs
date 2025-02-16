using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Functions.DataFunctions;
namespace Wolt_ConsoleApp.Functions;
internal class DataManagement
{
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }
    public static void DataManagementVoid()
    {
        DataContext _context = new DataContext();
        bool MainMenu = false;
        while (!MainMenu) {
            Clear();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Add Restaurant");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Edit Restaurant");
            Console.WriteLine("5. Remove Product");
            Console.WriteLine("6. Remove Restaurant");
            Console.WriteLine("7. Product List");
            Console.WriteLine("8. Restaurant List");
            Console.WriteLine("9. Main Menu");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Clear();
                MainMenu = true;
                AddProduct.AddProductToRestaurant();
            }
            else if (choice == "2")
            {
                Clear();
                MainMenu = true;
                AddRestaurant.AddRestaurantToDatabase();
            }
            else if (choice == "3") {
                Clear();
                MainMenu = true;
                EditProduct.EditProductToDatabase();
            }
            else if (choice == "4")
            {
                Clear();
                MainMenu = true;
                EditRestaurant.EditRestaurantVoid();
            }
            else if (choice == "5")
            {
                Clear();
                MainMenu = true;
            }
            else if (choice == "6")
            {
                Clear();
                MainMenu = true;
            }
            else if (choice == "7")
            {
                Clear();
                MainMenu = true;
                ProductList.ShowProductList();
            }
            else if (choice == "8")
            {
                Clear();
                MainMenu = true;
                RestaurantList.ShowRestaurantList();
            }
            else if (choice == "9")
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
