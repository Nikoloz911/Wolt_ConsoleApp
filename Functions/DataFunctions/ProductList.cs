﻿using Microsoft.EntityFrameworkCore;
using Wolt_ConsoleApp.Data;
namespace Wolt_ConsoleApp.Functions.DataFunctions;
internal class ProductList
{
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }
    public static bool ShowProductList()
    {
        using DataContext _context = new DataContext();
        var products = _context.Products
            .Include(a => a.Restaurants)
            .ToList();
        if (!products.Any())
        {
            Clear();
            Line();
            Console.WriteLine("No products available.");
            Line();
            return false;
        }
        int pageSize = 20;
        int currentIndex = 0;
        while (currentIndex < products.Count)
        {
            Clear();
            LineLong();
            var pagedProducts = products.Skip(currentIndex).Take(pageSize);
            foreach (var product in pagedProducts)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: {product.Id} - ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Name: {product.ProductName} | ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Price: {product.ProductPrice} | ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Quantity: {product.ProductQuantity} | ");
                Console.ResetColor();
                Console.ForegroundColor = product.IsAvailable ? ConsoleColor.Blue : ConsoleColor.Red;
                Console.Write($"Available: {product.IsAvailable} | ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Restaurant: {product.Restaurants?.RestaurantName ?? "N/A"}");
                Console.ResetColor();
            }
            LineLong();
            Console.WriteLine("1. See the next 20 products");
            Console.WriteLine("2. Back to Data Management menu");
            var choice = Console.ReadLine();
            Clear();
            if (choice == "2")
                return false;
            if (choice == "1")
                currentIndex += pageSize;
        }
        Clear();
        Line();
        Console.WriteLine("No More Products To Display.");
        Line();
        return true;
    }
}
