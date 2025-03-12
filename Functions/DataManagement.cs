using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Functions.DataFunctions;

namespace Wolt_ConsoleApp.Functions
{
    internal class DataManagement
    {
        public static readonly string filePath = "Products.txt";
        public static readonly string filePathRestaurant = "Restaurants.txt";
        public static void Clear() => Console.Clear();
        public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
        public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }
        public static void ColorLine(string text, ConsoleColor color)
        { Console.ForegroundColor = color; Console.WriteLine(text); Console.ResetColor(); }
        public static void WriteToFile(string data)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.AppendAllText(filePath, data + Environment.NewLine);
        }
        public static void WriteToFileRestaurant(string data)
        {
            if (!File.Exists(filePathRestaurant))
            {
                File.Create(filePathRestaurant).Close();
            }
            File.AppendAllText(filePathRestaurant, data + Environment.NewLine);
        }
        public static void DataManagementVoid()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            if (!File.Exists(filePathRestaurant))
            {
                File.Create(filePathRestaurant).Close();
            }
            DataContext _context = new DataContext();
            bool MainMenu = false;
            Clear();
            while (!MainMenu)
            {      
                ColorLine("1. Add Product", ConsoleColor.Green);
                ColorLine("2. Add Restaurant", ConsoleColor.Green);
                ColorLine("3. Edit Product", ConsoleColor.Yellow);
                ColorLine("4. Edit Restaurant" , ConsoleColor.Yellow);
                ColorLine("5. Remove Product", ConsoleColor.Red);
                ColorLine("6. Remove Restaurant", ConsoleColor.Red);
                ColorLine("7. Product List", ConsoleColor.Cyan);
                ColorLine("8. Restaurant List", ConsoleColor.Cyan);
                ColorLine("9. Main Menu", ConsoleColor.Green);
                string choice = Console.ReadLine()?.Trim();
                Clear();
                switch (choice)
                {
                    case "1":
                        MainMenu = AddProduct.AddProductToRestaurant();
                        break;
                    case "2":
                        MainMenu = AddRestaurant.AddRestaurantToDatabase();
                        break;
                    case "3":
                        MainMenu = EditProduct.EditProductToDatabase();
                        break;
                    case "4":
                        MainMenu = EditRestaurant.EditRestaurantVoid();
                        break;
                    case "5":
                        MainMenu = RemoveProduct.RemoveProductVoid();
                        break;
                    case "6":
                        MainMenu = RemoveRestaurant.RemoveRestaurantVoid();
                        break;
                    case "7":
                        MainMenu = ProductList.ShowProductList();
                        break;
                    case "8":
                        MainMenu = RestaurantList.ShowRestaurantList();
                        break;
                    case "9":
                        Clear();
                        MainMenu = true; // Exit to main menu
                        break;
                    default:
                        Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Line();
                        Console.WriteLine("Invalid Choice!");
                        Line();
                        Console.ResetColor();
                        MainMenu = false;
                        break;
                }
            }
        }
    }
}
