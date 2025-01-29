using Wolt_ConsoleApp.Models;

namespace Wolt_ConsoleApp.Data;
internal class Delete
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
    public static void DeleteTables()
    {
        DataContext _context = new DataContext();
        bool IsDeleted = false;
        while (!IsDeleted)
        {
            Clear();
            Console.WriteLine("1. Delete Users Table");
            Console.WriteLine("2. Delete Users Details Table");
            Console.WriteLine("3. Delete Restaurants Table");
            Console.WriteLine("4. Delete Products Table");
            Console.WriteLine("5. Delete Payments Table");
            Console.WriteLine("6. Delete Orders Table");
            Console.WriteLine("7. Delete OrderItems Table");
            Console.WriteLine("8. Delete CreditCards Table");
            Console.WriteLine("9. Delete ALL Table");
            Console.WriteLine("10. Exit");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                IsDeleted = true;
                List<User> users = _context.Users.ToList();
                if (users.Any()) _context.Users.RemoveRange(users);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("User Data Has Been Deleted");
                Line();
            }
            else if (choice == "2")
            {
                IsDeleted = true;
                List<UserDetails> usersDetails = _context.UsersDetails.ToList();   
                if (usersDetails.Any()) _context.UsersDetails.RemoveRange(usersDetails);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("User Details Data Has Been Deleted");
                Line();
            }
            else if (choice == "3")
            {
                IsDeleted = true;
                List<Restaurants> restaurants = _context.Restaurants.ToList();
                if (restaurants.Any()) _context.Restaurants.RemoveRange(restaurants);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("Restaurants Has Been Deleted");
                Line();
            }
            else if (choice == "4")
            {
                IsDeleted = true;
                List<Product> products = _context.Products.ToList();
                if (products.Any()) _context.Products.RemoveRange(products);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("Products Has Been Deleted");
                Line();
            }
            else if (choice == "5")
            {
                IsDeleted = true;
                List<Payment> payments = _context.Payments.ToList();
                if (payments.Any()) _context.Payments.RemoveRange(payments);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("Payments Has Been Deleted");
                Line();
            }
            else if (choice == "6")
            {
                IsDeleted = true;
                List<Order> orders = _context.Orders.ToList();
                if (orders.Any()) _context.Orders.RemoveRange(orders);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("Orders Has Been Deleted");
                Line();
            }
            else if (choice == "7")
            {
                IsDeleted = true;
                List<OrderItem> orderItems = _context.OrderItems.ToList();
                if (orderItems.Any()) _context.OrderItems.RemoveRange(orderItems);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("OrderItems Has Been Deleted");
                Line();
            }
            else if (choice == "8")
            {
                IsDeleted = true;
                List<CreditCard> creditCards = _context.CreditCards.ToList();
                if (creditCards.Any()) _context.CreditCards.RemoveRange(creditCards);
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("CreditCards Has Been Deleted");
                Line();
            }
            else if (choice == "9")
            {
                IsDeleted = true;
                /// ALL
                DeleteAllData(_context);
                /// ALL
            }
            else if (choice == "10")
            {
                Clear();
                IsDeleted = true; /// NOT TRUE
            }
            else
            {
                Clear();
                Line();
                Console.WriteLine("Invalid choice!");
                Line();
            }
        }
        /// DELETE ALL DATA FUNCTION  /// DELETE ALL DATA FUNCTION
        void DeleteAllData(DataContext _context)
        {
            List<User> users = _context.Users.ToList();
            List<UserDetails> usersDetails = _context.UsersDetails.ToList();
            List<Restaurants> restaurants = _context.Restaurants.ToList();
            List<Product> products = _context.Products.ToList();
            List<Payment> payments = _context.Payments.ToList();
            List<Order> orders = _context.Orders.ToList();
            List<OrderItem> orderItems = _context.OrderItems.ToList();
            List<CreditCard> creditCards = _context.CreditCards.ToList();
            if (creditCards.Any()) _context.CreditCards.RemoveRange(creditCards);
            if (orderItems.Any()) _context.OrderItems.RemoveRange(orderItems);
            if (orders.Any()) _context.Orders.RemoveRange(orders);
            if (payments.Any()) _context.Payments.RemoveRange(payments);
            if (products.Any()) _context.Products.RemoveRange(products);
            if (restaurants.Any()) _context.Restaurants.RemoveRange(restaurants);
            if (usersDetails.Any()) _context.UsersDetails.RemoveRange(usersDetails);
            if (users.Any()) _context.Users.RemoveRange(users);
            _context.SaveChanges();
            Clear();
            Line();
            Console.WriteLine("ALL Tables Data Has Been Deleted");
            Line();
        }
        /// DELETE ALL DATA FUNCTION  /// DELETE ALL DATA FUNCTION
    }
}








