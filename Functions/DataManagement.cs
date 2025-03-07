﻿using Wolt_ConsoleApp.Data;
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
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Add Restaurant");
                Console.WriteLine("3. Edit Product");
                Console.WriteLine("4. Edit Restaurant");
                Console.WriteLine("5. Remove Product");
                Console.WriteLine("6. Remove Restaurant");
                Console.WriteLine("7. Product List");
                Console.WriteLine("8. Restaurant List");
                Console.WriteLine("9. Main Menu");
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
                        Line();
                        Console.WriteLine("Invalid Choice!");
                        Line();
                        MainMenu = false;
                        break;
                }
            }
        }
    }
}
