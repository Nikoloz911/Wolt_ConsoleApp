using Wolt_ConsoleApp.Data;
namespace Wolt_ConsoleApp.Functions.UserFunctions;
internal class RemoveWoltPlus
{
    public static void Clear()
    {
        Console.Clear();
    }
    public static void InvalidChoice()
    {
        Clear();
        Line();
        Console.WriteLine("Invalid choice!");
        Line();
    }
    public static int Line()
    {
        int length = 55;
        string dashLine = new string('-', length);
        Console.WriteLine(dashLine);
        return length;
    }
    public static void UnpurchaseWoltPlus()
    {
        DataContext _context = new DataContext();
        Clear();
        bool isRemovedWoltPlus = false;
        while (!isRemovedWoltPlus)
        {
            Console.WriteLine("Enter User Name: ");
            string username = Console.ReadLine();
            if (string.IsNullOrEmpty(username))
            {
                if (!RetryOption("User Name Cannot Be Empty!"))
                    return;
                continue;
            }
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                if (!RetryOption("No user found with the entered username."))
                    return;
                continue;
            }
            if (!user.HasWoltPlus)
            {
                Clear();
                Line();
                Console.WriteLine("This user doesn't have WoltPlus.");
                Line();
                return;
            }
            Clear();
            Line();
            Console.WriteLine($"User: {user.UserName} currently has WoltPlus.");
            Line();

            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("Are you sure you want to cancel WoltPlus subscription?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                string confirmChoice = Console.ReadLine();
                if (confirmChoice == "1")
                {
                    user.HasWoltPlus = false;
                    _context.SaveChanges();
                    Clear();
                    Line();
                    Console.WriteLine("WoltPlus has been successfully cancelled!");
                    Line();
                    isRemovedWoltPlus = true;
                    validChoice = true;
                    // Write In File
                    string cancellationData = $"User: {user.UserName} {user.UserLastName} cancelled WoltPlus at {DateTime.Now}";
                    UserManagement.WriteToFile(cancellationData);
                }
                else if (confirmChoice == "2")
                {
                    Clear();
                    Line();
                    Console.WriteLine("WoltPlus cancellation aborted.");
                    Line();
                    return;
                }
                else
                {
                    if (!RetryOption("Invalid choice!"))
                        return;
                }
            }
        }
    }

    private static bool RetryOption(string errorMessage)
    {
        Clear();
        Line();
        Console.WriteLine(errorMessage);
        Line();
        Console.WriteLine("1. Try Again");
        Console.WriteLine("2. Exit");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Clear();
            return true;
        }
        else if (choice == "2")
        {
            Clear();
            return false;
        }
        else
        {
            InvalidChoice();
            return false;
        }
    }
}