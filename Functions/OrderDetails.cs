using Wolt_ConsoleApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Wolt_ConsoleApp.Functions;
internal class OrderDetails
{
    public static DataContext _context = new DataContext();
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }
    public static void ViewOrderDetails()
    {
        Clear();
        var AllOrders = _context.Orders
        .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
        .Include(o => o.Restaurant)
        .Include(o => o.Payment)
            .ThenInclude(p => p.CreditCard) 
        .Include(o => o.User)
        .ToList();
        if (AllOrders.Count == 0)
        {
            Line();
            Console.WriteLine("No orders found!");
            Line();
            return;
        }
        foreach (var order in AllOrders)
        {
            LineLong();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Order ID: {order.Id}, User: {order.User?.UserName} (ID: {order.UserId})");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Restaurant: {order.Restaurant?.RestaurantName} (ID: {order.RestaurantId})");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Status: {order.OrderStatus}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string maskedCard = "N/A";
            if (order.Payment?.CreditCard != null && !string.IsNullOrEmpty(order.Payment.CreditCard.CreditCardNumber))
            {
                string creditCardNumber = order.Payment.CreditCard.CreditCardNumber;
                maskedCard = "**** **** **** " + creditCardNumber[^4..];
            }
            Console.WriteLine($"Credit Card Id: {order.Payment?.CreditCardId}, Number: {maskedCard}, Total Paid: {order.Payment?.TotalAmount}$");
            Console.ResetColor(); 
            Line();
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in order.OrderItems)
            {
                Console.WriteLine($"- {item.Product?.ProductName} | Quantity: {item.Quantity} | Price: {item.Product?.ProductPrice}$");
            }
            Console.ResetColor();
        }
        LineLong();
    }
}
