using Wolt_ConsoleApp.Functions.UserFunctions;

namespace Wolt_ConsoleApp.Functions;
internal class UserManagement
{
    public static void Clear()
    {
        Console.Clear();
    }
    public static int Line()
    {
        int length = 55;
        string dashLine = new string('-', length);
        Console.WriteLine(dashLine);
        return length;
    }
    public static void UserManagementVoid()
    {
        bool MainMenu = false;
        while (!MainMenu)
        {
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Log In");
            Console.WriteLine("3. User List");
            Console.WriteLine("4. Main Menu");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                SingUp.UserSignUp();
            }
            else if (choice == "2")
            {
                LogIn.UserLogIn();
            }
            else if (choice == "3")
            {
                // LIST
            }
            else if (choice == "4")
            {
                Clear();
                MainMenu = true;
            }
            else
            {
                Clear();
                Line();
                Console.WriteLine("Invalid choice!");
                Line();
            }
        }

    }

}
