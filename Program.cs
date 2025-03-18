using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Functions;

static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
static void ColorLine(string text, ConsoleColor color)
{ Console.ForegroundColor = color; Console.WriteLine(text); Console.ResetColor(); }

/// First create the database and tables
/// Then remove this code from the comment below and populate the database with data.

//DataContext _context = new DataContext();
//AddData.AddRestaurantsAndProductsData(_context);

bool running = true;
while (running)
{
    ColorLine("1. User Management", ConsoleColor.Green);
    ColorLine("2. Data Management", ConsoleColor.Yellow);
    ColorLine("3. Order Products", ConsoleColor.Cyan);
    ColorLine("4. Order Details", ConsoleColor.Blue);
    ColorLine("5. Analytics", ConsoleColor.Yellow);
    ColorLine("6. File Management", ConsoleColor.Cyan);
    ColorLine("7. System", ConsoleColor.Green);
    ColorLine("8. Delete Database Table", ConsoleColor.Red);
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
        SystemFunction.SystemVoid();
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