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
    public static int LineLong()
    {
        int length = 100;
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
            Console.WriteLine("7. Add Balance");
            Console.WriteLine("8. Purchase Wolt+");
            Console.WriteLine("9. Main Menu");
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
                        LineLong();
                        Console.WriteLine($"{user.UserName} {user.UserLastName}  (Email: {user.UserDetails.UserEmail}) (Number: {user.UserDetails.UserPhoneNumber})  (Is Active: {user.IsActive})");
                        LineLong();
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
                AddCreditCard.AddUserCreditCard();
            }
            else if (choice == "6")
            {
                MainMenu = true;
                /// CREDIT CARD LIST  /// CREDIT CARD LIST  /// CREDIT CARD LIST
                Clear();
                var creditCardInfo = from card in _context.CreditCards
                                     join user in _context.Users on card.UserId equals user.Id
                                     select new
                                     {
                                         UserName = user.UserName,
                                         CreditCardNumber = card.CreditCardNumber,
                                         ExpiryDate = card.CreditCardExpiryDate.ToString("MM/dd/yyyy"),
                                         Balance = card.CreditCardBalance
                                     };
                if (creditCardInfo.Any())
                {
                    LineLong();
                    foreach (var card in creditCardInfo)
                    {
                        string fullCardNumber = card.CreditCardNumber; 
                        string last4Digits = fullCardNumber.Length >= 4 ? fullCardNumber.Substring(fullCardNumber.Length - 4) : fullCardNumber;
                        Console.WriteLine($"User Name: {card.UserName}, Card Number: **** **** **** {last4Digits}, Expiry Date: {card.ExpiryDate}, Balance: {card.Balance:C}");
                    }
                    LineLong();
                }
                else
                {
                    Clear();
                    Line();
                    Console.WriteLine("No credit cards found.");
                    Line();
                }
                /// CREDIT CARD LIST  /// CREDIT CARD LIST  /// CREDIT CARD LIST
            }
            else if (choice == "7")
            {
                Clear();
                MainMenu = true;
                AddBalance.AddBalanceToCreditCard();
            }
            else if (choice == "8")
            {
                Clear();
                MainMenu = true;
                WoltPlus.PurchaseWoltPlus();
            }
            else if (choice == "9")
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
