using Microsoft.EntityFrameworkCore;
using Wolt_ConsoleApp.Data;

namespace Wolt_ConsoleApp.Functions.LinqFunctions;
internal class All_LINQ
{
    public static DataContext _context = new DataContext();
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 115)); return 115; }


    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS 
    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS 
    /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS /// SORT USERS
    /// SORT BY USER NAME   /// SORT BY USER NAME   /// SORT BY USER NAME
    public static void SortUsersByName()
    {
        var users = _context.Users
            .Include(d => d.UserDetails)
            .OrderBy(u => u.UserName)
            .ToList();
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
            .OrderBy(u => u.Id)
            .ToList();
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
            .OrderBy(u => u.UserCreated)
            .ToList();
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
            .OrderBy(u => u.IsActive)
            .ToList();
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
            .OrderBy(u => u.HasWoltPlus)
            .ToList();
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
            .OrderByDescending(u => u.CreditCards.Count)
            .ToList();
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
            .OrderByDescending(u => u.CreditCards.Sum(c => c.CreditCardBalance))
            .ToList();
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
            .OrderByDescending(u => u.Payments.Sum(p => p.TotalAmount))
            .ToList();
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
            .OrderByDescending(u => u.Orders.Count)
            .ToList(); 
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
    /// SORT Credit Cards By Expiry Date   /// SORT Credit Cards By Expiry Date
    public static void SortCreditCardsByExpiryDate()
    {
        var creditCards = _context.CreditCards
            .Include(u => u.Users)
            .OrderBy(c => c.CreditCardExpiryDate)
            .ToList();
        LineLong();
        foreach (var creditCard in creditCards)
        {
            string cleanCardNumber = creditCard.CreditCardNumber.Replace(" ", "");
            string maskedCardNumber = new string('*', cleanCardNumber.Length - 4) + cleanCardNumber[^4..];
            string formattedCardNumber = string.Join(" ", Enumerable.Range(0, maskedCardNumber.Length / 4)
                .Select(i => maskedCardNumber.Substring(i * 4, Math.Min(4, maskedCardNumber.Length - i * 4))));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {creditCard.Users.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Card Number: {formattedCardNumber}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Expiry Date: {creditCard.CreditCardExpiryDate}, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"CVV: {creditCard.CreditCardCVV}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT Credit Cards By Expiry Date   /// SORT Credit Cards By Expiry Date
    /// SORT Credit Cards By Balance   /// SORT Credit Cards By Balance
    public static void SortCreditCardsByBalance()
    {
        var creditCards = _context.CreditCards
            .Include(u => u.Users)
            .OrderByDescending(c => c.CreditCardBalance)
            .ToList();
        LineLong();
        foreach (var creditCard in creditCards)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {creditCard.Users.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Card Balance: {creditCard.CreditCardBalance}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Expiry Date: {creditCard.CreditCardExpiryDate}, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"CVV: {creditCard.CreditCardCVV}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT Credit Cards By Balance   /// SORT Credit Cards By Balance
    /// SORT Credit Cards By Number of Transactions
    public static void SortCreditCardsByPayments()
    {
        var creditCards = _context.CreditCards
            .Include(u => u.Users)
            .OrderBy(c => c.CreditCardBalance)
            .ToList();
        LineLong();
        foreach (var creditCard in creditCards)
        {
            int paymentCount = _context.Payments.Count(p => p.CreditCardId == creditCard.Id);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {creditCard.Users.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Card Payments: {creditCard.CreditCardBalance}, ");
            Console.ForegroundColor = (paymentCount == 0) ? ConsoleColor.Red : ConsoleColor.Cyan;
            Console.Write($"Payments Count: {paymentCount}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Expiry Date: {creditCard.CreditCardExpiryDate}, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"CVV: {creditCard.CreditCardCVV}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT Credit Cards By Number of Transactions
    /// SORT CREDIT CARDS /// SORT CREDIT CARDS /// SORT CREDIT CARDS
    /// SORT CREDIT CARDS /// SORT CREDIT CARDS /// SORT CREDIT CARDS
    /// SORT PAYMENTS /// SORT PAYMENTS /// SORT PAYMENTS
    /// SORT PAYMENTS /// SORT PAYMENTS /// SORT PAYMENTS 
    /// SORT PAYMENTS BY TOTAL AMOUNT   /// SORT PAYMENTS BY TOTAL AMOUNT
    public static void SortPaymentsByTotalAmount()
    {
        var payments = _context.Payments
            .Include(u => u.User)
            .Include(c => c.CreditCard)
            .OrderByDescending(p => p.TotalAmount)
            .ToList();
        LineLong();
        foreach (var payment in payments)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {payment.User.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Payment Amount: {payment.TotalAmount}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Credit Card Holder Name: {payment.CreditCard.CreditCardHolderName}, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Payment Status: {payment.PaymentStatus}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT PAYMENTS BY TOTAL AMOUNT   /// SORT PAYMENTS BY TOTAL AMOUNT
    public static void SortPaymentsByStatus()
    {
        var payments = _context.Payments
            .Include(u => u.User)
            .Include(c => c.CreditCard)
            .OrderByDescending(p => p.PaymentStatus)
            .ToList();
        LineLong();
        foreach (var payment in payments)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {payment.User.UserName}, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Payment Amount: {payment.TotalAmount}, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Credit Card Holder Name: {payment.CreditCard.CreditCardHolderName}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Payment Status: {payment.PaymentStatus}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT PAYMENTS /// SORT PAYMENTS /// SORT PAYMENTS
    /// SORT PAYMENTS /// SORT PAYMENTS /// SORT PAYMENTS
    /// SORT ORDERS /// SORT ORDERS /// SORT ORDERS
    /// SORT ORDERS /// SORT ORDERS /// SORT ORDERS
    /// SORT ORDERS BY USERS /// SORT ORDERS BY USERS
    public static void SortOrdersByUsers()
    {
        var orders = _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .Include(o => o.Payment)
            .OrderBy(o => o.UserId)
            .ToList();
        LineLong();
        foreach (var order in orders)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {order.User.UserName}, ");
            int totalProductsOrdered = order.OrderItems.Sum(oi => oi.Quantity);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Total Products: {totalProductsOrdered}, ");
            decimal totalOrderAmount = order.Payment?.TotalAmount ?? 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Order Total: {totalOrderAmount:C}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Order Status: {order.OrderStatus}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT ORDERS BY USERS /// SORT ORDERS BY USERS
    /// SORT ORDERS BY RESTAURANTS  /// SORT ORDERS BY RESTAURANTS
    public static void SortOrdersByRestaurants()
    {
        var orders = _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                    .ThenInclude(p => p.Restaurants)
            .Include(o => o.Payment)
            .OrderBy(o => o.OrderItems
                .Where(oi => oi.Product.Restaurants != null)  
                .Select(oi => oi.Product.Restaurants.RestaurantName)
                .FirstOrDefault())
            .ToList();
        LineLong();
        foreach (var order in orders)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {order.User.UserName}, ");
            int totalProductsOrdered = order.OrderItems.Sum(oi => oi.Quantity);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Total Products: {totalProductsOrdered}, ");
            decimal totalOrderAmount = order.Payment?.TotalAmount ?? 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Order Total: {totalOrderAmount:C}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Order Status: {order.OrderStatus}, ");
            var restaurantNames = order.OrderItems
                .Select(oi => oi.Product.Restaurants?.RestaurantName)
                .Where(name => name != null)
                .Distinct()
                .ToList();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Restaurants: {string.Join(", ", restaurantNames)}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT ORDERS BY RESTAURANTS  /// SORT ORDERS BY RESTAURANTS
    /// SORT ORDERS BY STATUS  /// SORT ORDERS BY STATUS
    public static void SortOrdersByStatus()
    {
        var orders = _context.Orders
            .Include(o => o.User) 
            .Include(p => p.Payment)
            .OrderBy(o => o.OrderStatus) 
            .ToList();
        LineLong();
        foreach (var order in orders)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {order.User.UserName}, ");
            int totalProductsOrdered = order.OrderItems?.Sum(oi => oi.Quantity) ?? 0; 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Total Products: {totalProductsOrdered}, ");
            decimal totalOrderAmount = order.Payment?.TotalAmount ?? 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Order Total: {totalOrderAmount:C}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Order Status: {order.OrderStatus}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT ORDERS BY STATUS  /// SORT ORDERS BY STATUS
    /// SORT ORDERS /// SORT ORDERS /// SORT ORDERS
    /// SORT ORDERS /// SORT ORDERS /// SORT ORDERS
    /// SORT ORDER ITEMS /// SORT ORDER ITEMS /// SORT ORDER ITEMS
    /// SORT ORDER ITEMS /// SORT ORDER ITEMS /// SORT ORDER ITEMS
    /// SORT ORDER ITEMS BY NUMBER OF PRODUCTS INCLUDED
    public static void SortOrderItemsByProducts()
    {
        var orders = _context.OrderItems
       .Include(oi => oi.Order)
           .ThenInclude(o => o.User)
           .ThenInclude(p => p.Payments)
       .Include(oi => oi.Product)
       .OrderBy(oi => oi.Product.ProductName)
       .ToList();

        LineLong();
        foreach (var orderItem in orders)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {orderItem.Order.User.UserName}, ");
            int totalProductsOrdered = orderItem.Quantity;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Total Products: {totalProductsOrdered}, ");
            decimal totalOrderAmount = orderItem.Order.Payment?.TotalAmount ?? 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Order Total: {totalOrderAmount:C}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Order Status: {orderItem.Order.OrderStatus}, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            var productNames = new List<string> { orderItem.Product.ProductName };
            Console.WriteLine($"Product: {string.Join(", ", productNames)}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT ORDER ITEMS BY NUMBER OF PRODUCTS INCLUDED
    /// SORT ORDER ITEMS BY TOTAL PRICE   /// SORT ORDER ITEMS BY TOTAL PRICE
    public static void SortOrderItemsByTotalPrice()
    {
        var orders = _context.OrderItems
            .Include(oi => oi.Order)
                .ThenInclude(o => o.User)
            .Include(oi => oi.Product)
            .OrderByDescending(oi => oi.TotalPrice)
            .ToList();
        LineLong();
        foreach (var orderItem in orders)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {orderItem.Order.User.UserName}, ");
            int totalProductsOrdered = orderItem.Quantity;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Total Products: {totalProductsOrdered}, ");
            decimal totalOrderAmount = orderItem.TotalPrice; 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Order Total: {totalOrderAmount:C}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Order Status: {orderItem.Order.OrderStatus}, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            var productNames = new List<string> { orderItem.Product.ProductName };
            Console.WriteLine($"Product: {string.Join(", ", productNames)}");
            Console.ResetColor();
        }
        LineLong();
    }

    /// SORT ORDER ITEMS BY TOTAL PRICE   /// SORT ORDER ITEMS BY TOTAL PRICE
    /// SORT ORDER ITEMS BY TOTAL QUANTITY   /// SORT ORDER ITEMS BY TOTAL QUANTITY
    public static void SortOrderItemsByQuantity()
    {
        var orders = _context.OrderItems
            .Include(oi => oi.Order)
                .ThenInclude(o => o.User)
            .Include(oi => oi.Product)
            .OrderByDescending(oi => oi.Quantity)
            .ToList();
        LineLong();
        foreach (var orderItem in orders)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"User Name: {orderItem.Order.User.UserName}, ");
            int totalProductsOrdered = orderItem.Quantity;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Total Products: {totalProductsOrdered}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Ordered Products Quantity: {orderItem.Quantity}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Order Status: {orderItem.Order.OrderStatus}, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            var productNames = new List<string> { orderItem.Product.ProductName };
            Console.WriteLine($"Product: {string.Join(", ", productNames)}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT ORDER ITEMS BY TOTAL QUANTITY   /// SORT ORDER ITEMS BY TOTAL QUANTITY
    /// SORT ORDER ITEMS /// SORT ORDER ITEMS /// SORT ORDER ITEMS
    /// SORT ORDER ITEMS /// SORT ORDER ITEMS /// SORT ORDER ITEMS
}