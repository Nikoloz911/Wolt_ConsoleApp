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
            Clear();
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Log in User");
            Console.WriteLine("3. Log out User");
            Console.WriteLine("4. User List"); 
            Console.WriteLine("5. Add Credit Card");
            Console.WriteLine("6. Credit Card Information");
            Console.WriteLine("7. Main Menu");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                SingUp.UserSignUp();
                MainMenu = true;
            }
            else if (choice == "2")
            {
               
            }
            else if (choice == "3")
            {
               
            }
            else if (choice == "4")
            {
                // LIST
            }
            else if (choice == "5")
            {
                
            }
            else if (choice == "6")
            {

            }
            else if (choice == "7")
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
