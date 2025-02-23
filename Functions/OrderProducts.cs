using Wolt_ConsoleApp.Data;

namespace Wolt_ConsoleApp.Functions;

internal class OrderProducts
{
    public static DataContext _context = new DataContext();
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }

    public static void Order()
    {
        var allProducts = _context.Products.ToList();
        int startIndex = 0;
        const int productsToShow = 25;

        while (true)
        {
            Clear();
            LineLong();
            int totalPrinted = 0;

            for (int i = startIndex; i < allProducts.Count && totalPrinted < productsToShow; i++)
            {
                var product = allProducts[i];

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: {product.Id}, ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Product Name: {product.ProductName}, ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Price: {product.ProductPrice}, ");

                Console.ForegroundColor = product.IsAvailable ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"Is Available: {product.IsAvailable}, ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Quantity: {product.ProductQuantity}");

                Console.ResetColor();
                totalPrinted++;
            }

            LineLong();
            Console.WriteLine("Type 'N' For Next Products Or Choose Product ID / Enter Product Name:");
            var productChoice = Console.ReadLine();
            Clear();
            if (productChoice?.ToUpper() == "N")
            {
                startIndex += productsToShow;
                if (startIndex >= allProducts.Count)
                {
                    Line();
                    Console.WriteLine("No More Products");
                    Line();
                    break;
                }
                continue;
            }

            var foundProduct = _context.Products
                .FirstOrDefault(p => p.ProductName.ToLower() == productChoice.ToLower() || p.Id.ToString() == productChoice);
            /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT
            /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT
            if (foundProduct != null)
            {
                Console.WriteLine($"Ordering Product: {foundProduct.ProductName} (ID: {foundProduct.Id})");
            }
            /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT
            /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT
            else
            {
                Line();
                Console.WriteLine($"Product {productChoice} Was Not Found");
                Line();
            }
            break;
        }
    }
}
