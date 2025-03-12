using Wolt_ConsoleApp.Functions.UserFunctions;
using Wolt_ConsoleApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Wolt_ConsoleApp.Functions;
internal class UserManagement
{
    public static readonly string filePath = "User.txt";
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 120)); return 120; }
    public static void ColorLine(string text, ConsoleColor color)
    { Console.ForegroundColor = color; Console.WriteLine(text); Console.ResetColor(); }
    public static void WriteToFile(string data)
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        File.AppendAllText(filePath, data + Environment.NewLine);
    }
    public static bool UserManagementVoid()
    {

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        DataContext _context = new DataContext();
        bool MainMenu = false;
        Clear();
        while (!MainMenu)
        {
            ColorLine("1. Sign Up", ConsoleColor.Green);
            ColorLine("2. Log in User", ConsoleColor.Cyan);
            ColorLine("3. Log out User", ConsoleColor.Red);
            ColorLine("4. User List", ConsoleColor.Yellow);
            ColorLine("5. Add Credit Card", ConsoleColor.Green);
            ColorLine("6. Credit Card Information", ConsoleColor.Blue);
            ColorLine("7. Add Balance", ConsoleColor.Yellow);
            ColorLine("8. Purchase Wolt+", ConsoleColor.Green);
            ColorLine("9. Cancel WoltPlus Subscription", ConsoleColor.Red);
            ColorLine("10. Main Menu", ConsoleColor.Green);
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SingUp.UserSignUp();
                    break;
                case "2":
                    LogIn.UserLogIn();
                    break;
                case "3":
                    LogOut.UserLogOut();
                    break;
                case "4":
                    /// USER LIST  /// USER LIST  /// USER LIST
                    _context.ChangeTracker.Clear(); 
                    var users = _context.Users
                                        .OrderBy(u => u.UserName)
                                        .Include(d => d.UserDetails)
                                        .AsNoTracking()
                                        .ToList();
                    Clear();
                    if (users.Any())
                    {
                        Console.WriteLine("Users:");
                        foreach (var user in users)
                        {
                            LineLong();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"Name: {user.UserName}, LastName: {user.UserLastName}, ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"Email: {user.UserDetails.UserEmail}, ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Number: {user.UserDetails.UserPhoneNumber}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"Address: {user.UserDetails.UserAddress}, ");
                            Console.ForegroundColor = user.IsActive ? ConsoleColor.Green : ConsoleColor.Red;
                            Console.Write($"Is Active: {user.IsActive}, ");
                            Console.ForegroundColor = user.HasWoltPlus ? ConsoleColor.Green : ConsoleColor.Red;
                            Console.WriteLine($"Has Wolt+: {user.HasWoltPlus}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"User Created: {user.UserCreated}, Password: {user.UserPassword}");
                            Console.ResetColor();
                        }
                        LineLong();
                    }
                    else
                    {
                        Line();
                        Console.WriteLine("No users found.");
                        Line();
                        MainMenu = true;
                    }
                    break;
                /// USER LIST  /// USER LIST  /// USER LIST
                case "5":
                    AddCreditCard.AddUserCreditCard();
                    break;
                case "6":
                    /// CREDIT CARD LIST  /// CREDIT CARD LIST  /// CREDIT CARD LIST
                    var creditCardInfo = from card in _context.CreditCards
                                         join user in _context.Users on card.UserId equals user.Id
                                         select new
                                         {
                                             UserName = user.UserName,
                                             CreditCardNumber = card.CreditCardNumber,
                                             CreditCardCVV = card.CreditCardCVV,
                                             ExpiryDate = card.CreditCardExpiryDate.ToString("MM/dd/yyyy"),
                                             Balance = card.CreditCardBalance
                                         };
                    Clear();
                    if (creditCardInfo.Any())
                    {
                        LineLong();
                        foreach (var card in creditCardInfo)
                        {
                            string last4Digits = card.CreditCardNumber.Length >= 4 ? card.CreditCardNumber[^4..] : card.CreditCardNumber;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"User Name: {card.UserName}, ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"Card Number: **** **** **** {last4Digits}, ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"Expiry Date: {card.ExpiryDate}, ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"Balance: {card.Balance:C}, ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"CVV: {card.CreditCardCVV}");
                            Console.ResetColor();
                        }
                        LineLong();
                    }
                    else
                    {
                        Line();
                        Console.WriteLine("No credit cards found.");
                        Line();
                        MainMenu = true;
                    }
                    break;
                /// CREDIT CARD LIST  /// CREDIT CARD LIST  /// CREDIT CARD LIST

                case "7":
                    AddBalance.AddBalanceToCreditCard();
                    break;
                case "8":
                    WoltPlus.PurchaseWoltPlus();
                    break;
                case "9":
                    RemoveWoltPlus.UnpurchaseWoltPlus();
                    break;
                case "10":
                    Clear();
                    MainMenu = true; 
                    return true;
                default:
                    Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Line();
                    Console.WriteLine("Invalid choice!");
                    Line();
                    Console.ResetColor();
                    break;
            }
        }
        return false;
    }
}
