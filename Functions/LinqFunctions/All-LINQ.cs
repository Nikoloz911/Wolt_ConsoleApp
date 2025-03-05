using Microsoft.EntityFrameworkCore;
using Wolt_ConsoleApp.Data;

namespace Wolt_ConsoleApp.Functions.LinqFunctions;
internal class All_LINQ
{
    public static DataContext _context = new DataContext();
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 110)); return 110; }


    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS 
    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS 
    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS
    /// SORT BY USER NAME   /// SORT BY USER NAME   /// SORT BY USER NAME
    public static void SortUsersByName()
    {
        var users = _context.Users
            .Include(d => d.UserDetails)
            .OrderBy(u => u.UserName);
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Last Name: {user.UserLastName}, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Number: {user.UserDetails.UserPhoneNumber}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Email: {user.UserDetails.UserEmail}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT BY USER NAME   /// SORT BY USER NAME   /// SORT BY USER NAME
    /// SORT BY USER ID   /// SORT BY USER ID   /// SORT BY USER ID
    public static void SortUsersById()
    {
        var users = _context.Users
            .Include(d => d.UserDetails)
            .OrderBy(u => u.Id);
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.Id}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Last Name: {user.UserLastName}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Email: {user.UserDetails.UserEmail}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT BY USER ID   /// SORT BY USER ID   /// SORT BY USER ID
    /// SORT BY ACCOUNT CREATION DATE   /// SORT BY ACCOUNT CREATION DATE
    public static void SortUsersByUserCreatedDate()
    {
        var users = _context.Users
            .Include(d => d.UserDetails)
            .OrderBy(u => u.UserCreated);
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.Id}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"User Created: {user.UserCreated}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Email: {user.UserDetails.UserEmail}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT BY ACCOUNT CREATION DATE   /// SORT BY ACCOUNT CREATION DATE
    /// SORT BY ACTIVE STATUS   /// SORT BY ACTIVE STATUS   /// SORT BY ACTIVE STATUS
    public static void SortUsersByActiveStatus()
    {
        var users = _context.Users
            .Include(d => d.UserDetails)
            .OrderBy(u => u.IsActive);
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User ID: {user.Id}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = user.IsActive ? ConsoleColor.Yellow : ConsoleColor.Red;
            Console.Write($"Is Active: {user.IsActive}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Email: {user.UserDetails.UserEmail}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT BY ACTIVE STATUS   /// SORT BY ACTIVE STATUS   /// SORT BY ACTIVE STATUS
    /// SORT BY WOLT PLUS SUBSCRIPTION   /// SORT BY WOLT PLUS SUBSCRIPTION
    public static void SortUsersByWoltPlusSubscription()
    {
        var users = _context.Users
            .Include(d => d.UserDetails)
            .OrderBy(u => u.HasWoltPlus);
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User ID: {user.Id}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = user.HasWoltPlus ? ConsoleColor.Yellow : ConsoleColor.Red;
            Console.Write($"Has Wolt+: {user.HasWoltPlus}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Email: {user.UserDetails.UserEmail}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT BY WOLT PLUS SUBSCRIPTION   /// SORT BY WOLT PLUS SUBSCRIPTION
    /// SORT BY USER'S CREDIT CARD COUNT   /// SORT BY USER'S CREDIT CARD COUNT
    public static void SortUsersByLinkedCreditCards()
    {
        var users = _context.Users
            .Include(c => c.CreditCards)
            .Include(d => d.UserDetails)
            .OrderByDescending(u => u.CreditCards.Count);
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User ID: {user.Id}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Email: {user.UserDetails.UserEmail}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Credit Cards: {user.CreditCards.Count}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT BY USER'S CREDIT CARD COUNT   /// SORT BY USER'S CREDIT CARD COUNT
    /// SORT BY USER'S TOTAL CREDIT CARD BALANCE  
    public static void SortUsersByCreditCardsBalance()
    {
        var users = _context.Users
            .Include(c => c.CreditCards)
            .Include(d => d.UserDetails)
            .OrderByDescending(u => u.CreditCards.Sum(c => c.CreditCardBalance));
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User ID: {user.Id}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Email: {user.UserDetails.UserEmail}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total Credit Card Balance: {user.CreditCards.Sum(c => c.CreditCardBalance)}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT BY USER'S TOTAL CREDIT CARD BALANCE  
    /// SORT BY USER'S TOTAL PAYMENTS MADE  /// SORT BY USER'S TOTAL PAYMENTS MADE
    public static void SortUsersByTotalPayments()
    {
        var users = _context.Users
            .Include(d => d.UserDetails)
            .Include(p => p.Payments)
            .OrderByDescending(u => u.Payments.Sum(p => p.TotalAmount));
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User ID: {user.Id}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Email: {user.UserDetails.UserEmail}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Payments Count: {user.Payments.Count}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total Paid: {user.Payments.Sum(p => p.TotalAmount)}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT BY USER'S TOTAL PAYMENTS MADE  /// SORT BY USER'S TOTAL PAYMENTS MADE
    /// SORT BY USER'S TOTAL ORDERED PRODUCTS  /// SORT BY USER'S TOTAL ORDERED PRODUCTS
    public static void SortUsersByOrderedProducts()
    {
        var users = _context.Users
            .Include(d => d.UserDetails)               
            .Include(o => o.Orders)  
                .ThenInclude(oi => oi.OrderItems)    
            .OrderByDescending(u => u.Orders.Count); 
        LineLong();
        foreach (var user in users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User ID: {user.Id}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {user.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Email: {user.UserDetails.UserEmail}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Orders Count: {user.Orders.Count}, ");
 
            int totalOrderedProducts = user.Orders
                .SelectMany(o => o.OrderItems)  
                .Sum(oi => oi.Quantity);       

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Total Products Ordered: {totalOrderedProducts}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT BY USER'S TOTAL ORDERED PRODUCTS  /// SORT BY USER'S TOTAL ORDERED PRODUCTS
    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS 
    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS 
    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS
    /// SORT CREDIT CARDS /// SORT CREDIT CARDS /// SORT CREDIT CARDS

    /// SORT CREDIT CARDS /// SORT CREDIT CARDS /// SORT CREDIT CARDS
}