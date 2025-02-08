using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Functions;
using Wolt_ConsoleApp.Models;
void Line() => Console.WriteLine(new string('-', 60));

DataContext _context = new DataContext();

// AddData.AddRestaurantsAndProductsData(_context);

bool running = true;
while (running)
{
    Console.WriteLine("1. User Management");
    Console.WriteLine("2. Product Management");
    Console.WriteLine("3. Restaurants Management");
    Console.WriteLine("4. Analytics");
    Console.WriteLine("5. File Management");
    Console.WriteLine("6. System Logs");
    Console.WriteLine("7. Delete Database Table");
    Console.WriteLine("8. Exit App");
    string choice = Console.ReadLine();
    if (choice == "1")
    {
        UserManagement.UserManagementVoid();
    }
    else if (choice == "2")
    {
        ProductManagement.ProductManagementVoid();
    }
    else if (choice == "3")
    {
        RestaurantManagement.RestaurantManagementVoid();
    }
    else if (choice == "4")
    {
        Analytics.AnalyticsVoid();
    }
    else if (choice == "5")
    {
        FileManagement.FileManagementVoid();
    }
    else if (choice == "6")
    {
        SystemLogs.SystemLogsVoid();
    }
    else if (choice == "7")
    {
        Delete.DeleteTables();
    }
    else if (choice == "8")
    {
        Environment.Exit(0);
    }
    else
    {
        Line();
        Console.WriteLine("Invalid choice");
        Line();
    }
}