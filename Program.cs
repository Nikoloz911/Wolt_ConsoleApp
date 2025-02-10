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
    Console.WriteLine("2. Data Management");
    Console.WriteLine("3. Analytics");
    Console.WriteLine("4. File Management");
    Console.WriteLine("5. System Logs");
    Console.WriteLine("6. Delete Database Table");
    Console.WriteLine("7. Exit App");
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
        Analytics.AnalyticsVoid();
    }
    else if (choice == "4")
    {
        FileManagement.FileManagementVoid();
    }
    else if (choice == "5")
    {
        SystemLogs.SystemLogsVoid();
    }
    else if (choice == "6")
    {
        Delete.DeleteTables();
    }
    else if (choice == "7")
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