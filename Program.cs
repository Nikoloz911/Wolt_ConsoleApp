using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Functions;

static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
//DataContext _context = new DataContext();
//AddData.AddRestaurantsAndProductsData(_context);

bool running = true;
while (running)
{
    Console.WriteLine("1. User Management");
    Console.WriteLine("2. Data Management");  
    Console.WriteLine("3. Order Products");
    Console.WriteLine("4. Order Details");
    Console.WriteLine("5. Analytics");
    Console.WriteLine("6. File Management");
    Console.WriteLine("7. System Logs");
    Console.WriteLine("8. Delete Database Table");
    string choice = Console.ReadLine();
    if (choice == "1")
    {
        UserManagement.UserManagementVoid();
    }
    else if (choice == "2")
    {
        DataManagement.DataManagementVoid();
    }
    else if (choice == "3")
    {
        OrderProducts.Order();
    }
    else if (choice == "4")
    {
        OrderDetails.ViewOrderDetails();
    }
    else if (choice == "5")
    {
        Analytics.AnalyticsVoid();
    }
    else if (choice == "6")
    {
        FileManagement.FileManagementVoid();
    }
    else if (choice == "7")
    {
        SystemLogs.SystemLogsVoid();
    }
    else if (choice == "8")
    {
        Delete.DeleteTables();
    }
    else
    {
        Console.Clear();
        Line();
        Console.WriteLine("Invalid choice!");
        Line();
    }
}