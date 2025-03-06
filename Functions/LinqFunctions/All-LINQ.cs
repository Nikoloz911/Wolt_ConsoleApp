using Microsoft.EntityFrameworkCore;
using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Models;

namespace Wolt_ConsoleApp.Functions.LinqFunctions;
internal class All_LINQ
{
    public static DataContext _context = new DataContext();
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 115)); return 115; }
    public static void NoDataFound()
    {
        Console.WriteLine("No Data found in Database!");
        return;
    }

    // ALL LINQ FUNCTIONS

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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (users.Count == 0)
        {
            NoDataFound();
        }
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
        if (creditCards.Count == 0)
        {
            NoDataFound();
        }
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
        if (creditCards.Count == 0)
        {
            NoDataFound();
        }
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
        if (creditCards.Count == 0)
        {
            NoDataFound();
        }
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
        if (payments.Count == 0)
        {
            NoDataFound();
        }
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
        if (payments.Count == 0)
        {
            NoDataFound();
        }
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
        if (orders.Count == 0)
        {
            NoDataFound();
        }
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
        if (orders.Count == 0)
        {
            NoDataFound();
        }
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
            .Include(oi => oi.OrderItems)
            .ThenInclude(a => a.Product)
            .Include(p => p.Payment)
            .OrderBy(o => o.OrderStatus) 
            .ToList();
        LineLong();
        if (orders.Count == 0)
        {
            NoDataFound();
        }
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
        if (orders.Count == 0)
        {
            NoDataFound();
        }
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
        if (orders.Count == 0)
        {
            NoDataFound();
        }
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
        if (orders.Count == 0)
        {
            NoDataFound();
        }
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
    /// SORT PRODUCTS /// SORT PRODUCTS /// SORT PRODUCTS
    /// SORT PRODUCTS /// SORT PRODUCTS /// SORT PRODUCTS
    /// SORT PRODUCTS BY RESTAURANTS   /// SORT PRODUCTS BY RESTAURANTS
    public static void SortProductsByRestaurantsName()
    {
        var products = _context.Products
            .Include(r => r.Restaurants)
            .OrderBy(p => p.Restaurants.RestaurantName)
            .ToList();
        if (products.Count == 0)
        {
            LineLong();
            NoDataFound();
        }
        int pageSize = 20;
        int currentIndex = 0;
        while (currentIndex < products.Count)
        {
            Clear(); 
            LineLong();
            for (int i = currentIndex; i < currentIndex + pageSize && i < products.Count; i++)
            {
                var product = products[i];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Product Name: {product.ProductName}, ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"Price: {product.ProductPrice}, ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Quantity: {product.ProductQuantity}, ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Restaurant: {product.Restaurants.RestaurantName}");
                Console.ResetColor();
                Console.WriteLine();
            }
            LineLong();
            if (currentIndex + pageSize >= products.Count)
            {
                break;
            }
            Console.WriteLine("Type 'N' to show more or press Enter to exit:");
            string input = Console.ReadLine()?.Trim().ToUpper();
            if (input == "N")
            {
                currentIndex += pageSize;
            }
            else
            {
                Clear();
                break; 
            }
        }
    }

    /// SORT PRODUCTS BY RESTAURANTS   /// SORT PRODUCTS BY RESTAURANTS
    /// SORT PRODUCTS BY AVAILABLE STATUS   /// SORT PRODUCTS BY AVAILABLE STATUS
    public static void SortProductsByIsAvailable()
    {
        var products = _context.Products
            .Include(r => r.Restaurants)
            .OrderBy(p => p.IsAvailable)
            .ToList();
        if (products.Count == 0)
        {
            LineLong();
            NoDataFound();
        }
        int pageSize = 20;
        int currentIndex = 0;
        while (currentIndex < products.Count)
        {
            Clear();
            LineLong();
            for (int i = currentIndex; i < currentIndex + pageSize && i < products.Count; i++)
            {
                var product = products[i];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Product Name: {product.ProductName}, ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"Price: {product.ProductPrice}, ");
                if (product.IsAvailable)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Is Available: {(product.IsAvailable ? "Available" : "Unavailable")}, ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Quantity: {product.ProductQuantity}, ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Restaurant: {product.Restaurants.RestaurantName}");
                Console.ResetColor();
                Console.WriteLine();
            }
            LineLong();
            if (currentIndex + pageSize >= products.Count)
            {
                break;
            }
            Console.WriteLine("Type 'N' to show more or press Enter to exit:");
            string input = Console.ReadLine()?.Trim().ToUpper();
            if (input == "N")
            {
                currentIndex += pageSize;
            }
            else
            {
                Clear();
                break;
            }
        }
    }
    /// SORT PRODUCTS BY AVAILABLE STATUS   /// SORT PRODUCTS BY AVAILABLE STATUS
    /// SORT PRODUCTS BY QUANTITY   /// SORT PRODUCTS BY QUANTITY
    public static void SortProductsByQuantity()
    {
        var products = _context.Products
            .Include(r => r.Restaurants)
            .OrderBy(p => p.ProductQuantity)
            .ToList();
        if (products.Count == 0)
        {
            LineLong();
            NoDataFound();
        }
        int pageSize = 20;
        int currentIndex = 0;
        while (currentIndex < products.Count)
        {
            Clear();
            LineLong();
            for (int i = currentIndex; i < currentIndex + pageSize && i < products.Count; i++)
            {
                var product = products[i];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Product Name: {product.ProductName}, ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"Price: {product.ProductPrice}, ");
                Console.ForegroundColor = product.ProductQuantity == 0.00m ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write($"Quantity: {product.ProductQuantity}, ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Restaurant: {product.Restaurants.RestaurantName}");
                Console.ResetColor();
                Console.WriteLine();
            }
            LineLong();
            if (currentIndex + pageSize >= products.Count)
            {
                break;
            }
            Console.WriteLine("Type 'N' to show more or press Enter to exit:");
            string input = Console.ReadLine()?.Trim().ToUpper();
            if (input == "N")
            {
                currentIndex += pageSize;
            }
            else
            {
                Clear();
                break;
            }
        }
    }
    /// SORT PRODUCTS BY QUANTITY   /// SORT PRODUCTS BY QUANTITY
    /// SORT PRODUCTS BY PRICE   /// SORT PRODUCTS BY PRICE
    public static void SortProductsByPrice()
    {
        var products = _context.Products
            .Include(r => r.Restaurants)
            .OrderBy(p => p.ProductPrice)
            .ToList();
        if (products.Count == 0)
        {
            LineLong();
            NoDataFound();
        }
        int pageSize = 20;
        int currentIndex = 0;
        while (currentIndex < products.Count)
        {
            Clear();
            LineLong();
            for (int i = currentIndex; i < currentIndex + pageSize && i < products.Count; i++)
            {
                var product = products[i];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Product Name: {product.ProductName}, ");
                Console.ForegroundColor = product.ProductPrice == 0.00m ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write($"Price: {product.ProductPrice}, ");
                Console.ForegroundColor = product.ProductQuantity == 0.00m ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write($"Quantity: {product.ProductQuantity}, ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Restaurant: {product.Restaurants.RestaurantName}");
                Console.ResetColor();
                Console.WriteLine();
            }
            LineLong();
            if (currentIndex + pageSize >= products.Count)
            {
                break;
            }
            Console.WriteLine("Type 'N' to show more or press Enter to exit:");
            string input = Console.ReadLine()?.Trim().ToUpper();
            if (input == "N")
            {
                currentIndex += pageSize;
            }
            else
            {
                Clear();
                break;
            }
        }
    }
    /// SORT PRODUCTS BY PRICE   /// SORT PRODUCTS BY PRICE
    /// SORT PRODUCTS /// SORT PRODUCTS /// SORT PRODUCTS
    /// SORT PRODUCTS /// SORT PRODUCTS /// SORT PRODUCTS
    /// SORT RESTAURANTS /// SORT RESTAURANTS /// SORT RESTAURANTS
    /// SORT RESTAURANTS /// SORT RESTAURANTS /// SORT RESTAURANTS
    /// SORT RESTAURANTS BY ACCOUNT BALANCE   /// SORT RESTAURANTS BY ACCOUNT BALANCE
    public static void SortRestaurantsByAccountBalance()
    {
        var restaurants = _context.Restaurants
            .OrderByDescending(r => r.RestaurantBalance)
            .ToList();
        LineLong();
        if (restaurants.Count == 0)
        {
            NoDataFound();
        }
        foreach (var restaurant in restaurants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Restaurant Name: {restaurant.RestaurantName}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Balance: {restaurant.RestaurantBalance}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Rating: {restaurant.Rating}, ");
            Console.ForegroundColor = restaurant.DeliveryAvailable ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Delivery: {restaurant.DeliveryAvailable}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT RESTAURANTS BY ACCOUNT BALANCE   /// SORT RESTAURANTS BY ACCOUNT BALANCE
    /// SORT RESTAURANTS BY RATING   /// SORT RESTAURANTS BY RATING
    public static void SortRestaurantsByRating()
    {
        var restaurants = _context.Restaurants
            .OrderByDescending(r => r.Rating)
            .ToList();
        LineLong();
        if (restaurants.Count == 0)
        {
            NoDataFound();
        }
        foreach (var restaurant in restaurants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Restaurant Name: {restaurant.RestaurantName}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Balance: {restaurant.RestaurantBalance}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Rating: {restaurant.Rating}, ");
            Console.ForegroundColor = restaurant.DeliveryAvailable ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Delivery: {restaurant.DeliveryAvailable}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT RESTAURANTS BY RATING   /// SORT RESTAURANTS BY RATING
    /// SORT RESTAURANTS BY DELIVERY AVAILABILITY 
    public static void SortRestaurantsByDeliveryAvailable()
    {
        var restaurants = _context.Restaurants
            .OrderByDescending(r => r.DeliveryAvailable)
            .ToList();
        LineLong();
        if (restaurants.Count == 0)
        {
            NoDataFound();
        }
        foreach (var restaurant in restaurants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Restaurant Name: {restaurant.RestaurantName}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Balance: {restaurant.RestaurantBalance}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Rating: {restaurant.Rating}, ");
            Console.ForegroundColor = restaurant.DeliveryAvailable ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Delivery: {restaurant.DeliveryAvailable}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT RESTAURANTS BY DELIVERY AVAILABILITY
    /// SORT RESTAURANTS BY NUMBER OF ORDERS RECEIVED
    public static void SortRestaurantsByOrders()
    {
        var restaurants = _context.Restaurants
            .Include(o => o.Orders)
            .OrderByDescending(r => r.DeliveryAvailable)
            .ToList();
        LineLong();
        if (restaurants.Count == 0)
        {
            NoDataFound();
        }
        foreach (var restaurant in restaurants)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Restaurant Name: {restaurant.RestaurantName}, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Balance: {restaurant.RestaurantBalance}, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Rating: {restaurant.Rating}, ");
            Console.ForegroundColor = restaurant.DeliveryAvailable ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"Delivery: {restaurant.DeliveryAvailable}, ");
            if (restaurant.Orders.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"Total Orders Recieved: {restaurant.Orders.Count}");
            Console.ResetColor();
        }
        LineLong();
    }
    /// SORT RESTAURANTS BY NUMBER OF ORDERS RECEIVED
    /// SORT RESTAURANTS /// SORT RESTAURANTS /// SORT RESTAURANTS
    /// SORT RESTAURANTS /// SORT RESTAURANTS /// SORT RESTAURANTS
}
// ALL LINQ FUNCTIONS