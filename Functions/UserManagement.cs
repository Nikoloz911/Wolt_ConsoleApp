using Wolt_ConsoleApp.Functions.UserFunctions;
using Wolt_ConsoleApp.Data;
using Microsoft.EntityFrameworkCore;
namespace Wolt_ConsoleApp.Functions;
internal class UserManagement
{
    public static void Clear()
    {
        Console.Clear();
    }
    public static int Line()
    {
        int length = 60;
        string dashLine = new string('-', length);
        Console.WriteLine(dashLine);
        return length;
    }
    public static void UserManagementVoid()
    {
        DataContext _context = new DataContext();
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
                MainMenu = true;
                LogIn.UserLogIn();
            }
            else if (choice == "3")
            {
                MainMenu = true;
                LogOut.UserLogOut();
            }
            /// USER LIST   /// USER LIST   /// USER LIST   /// USER LIST   
            else if (choice == "4")
            {
                MainMenu = true;
                var users = _context.Users
                                    .OrderBy(u => u.UserName) 
                                    .Include(d => d.UserDetails)
                                    .ToList();

                if (users.Any())
                {
                    Clear();
                    foreach (var user in users)
                    {
                        Line();
                        Console.WriteLine($"{user.UserName} {user.UserLastName}  --- {user.UserDetails.UserEmail} --- {user.UserDetails.UserPhoneNumber}");
                        Line();
                    }
                }
                else
                {
                    Clear();
                    Line();
                    Console.WriteLine("No users found.");
                    Line();
                }
            }
            /// USER LIST   /// USER LIST   /// USER LIST   /// USER LIST   
            else if (choice == "5")
            {
                MainMenu = true;
            }
            else if (choice == "6")
            {
                MainMenu = true;
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
