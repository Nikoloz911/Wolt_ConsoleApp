using Wolt_ConsoleApp.Data;
using FluentValidation;
using Wolt_ConsoleApp.Validators;
using Wolt_ConsoleApp.Enums;
using Wolt_ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
namespace Wolt_ConsoleApp.Functions;

internal class OrderProducts
{
    public static DataContext _context = new DataContext();
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }

    public static void Order()
    {
        var allProducts = _context.Products.ToList();
        int startIndex = 0;
        const int productsToShow = 25;

        while (true)
        {
            Clear();
            LineLong();
            int totalPrinted = 0;

            for (int i = startIndex; i < allProducts.Count && totalPrinted < productsToShow; i++)
            {
                var product = allProducts[i];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: {product.Id}, ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Product Name: {product.ProductName}, ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Price: {product.ProductPrice}, ");
                Console.ForegroundColor = product.IsAvailable ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"Is Available: {product.IsAvailable}, ");
                Console.ForegroundColor = product.ProductQuantity == 0m ? ConsoleColor.Red : ConsoleColor.Cyan;
                Console.WriteLine($"Quantity: {product.ProductQuantity}");
                Console.ResetColor();
                totalPrinted++;
            }

            LineLong();
            Console.WriteLine("Type 'N' For Next Products Or Enter Product ID / Name:");
            var productChoice = Console.ReadLine();
            Clear();
            if (productChoice?.ToUpper() == "N")
            {
                startIndex += productsToShow;
                if (startIndex >= allProducts.Count)
                {
                    Line();
                    Console.WriteLine("No More Products");
                    Line();
                    break;
                }
                continue;
            }

            var foundProduct = _context.Products
                .Include(Restaurants => Restaurants.Restaurants)
                .FirstOrDefault(p => p.ProductName.ToLower() == productChoice.ToLower() || p.Id.ToString() == productChoice);
            /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT
            /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT
            if (foundProduct != null)
            {
                if (foundProduct.IsAvailable == false)
                {
                    if (HandleRetry($"Product {foundProduct.ProductName} is Not Available"))
                        return;
                    continue;
                }
                if (foundProduct.Restaurants == null)
                {
                    if (HandleRetry($"No restaurant information available for this product"))
                        return;
                    continue;
                }
                if (foundProduct.Restaurants.DeliveryAvailable == false)
                {
                    if (HandleRetry($"Delivery not available for this restaurant"))
                        return;
                    continue;
                }
                void ShowOrderingProduct()
                {
                    Clear();
                    LineLong();
                    Console.WriteLine($"Ordering Product: {foundProduct.ProductName}, ID: {foundProduct.Id}, Quantity: {foundProduct.ProductQuantity}, Price: {foundProduct.ProductPrice}");
                    LineLong();
                }

                bool HandleRetry(string message)
                {
                    Clear();
                    Line();
                    Console.WriteLine(message);
                    Line();
                    Console.WriteLine("1. Try again");
                    Console.WriteLine("2. Main Menu");
                    string input = Console.ReadLine();
                    Clear();
                    if (input == "2")
                    {
                        return true;
                    }
                    else if (input == "1")
                    {
                        return false;
                    }
                    Line();
                    Console.WriteLine("Invalid Choice");
                    Line();
                    return true;
                }
                void HandleUserInput()
                {
                    User user = null;
                    int productQuantity = 0;
                    CreditCard selectedCard = null;
                    while (true)
                    {
                        ShowOrderingProduct();
                        Console.WriteLine("Enter User Name:");
                        string userName = Console.ReadLine();
                        user = _context.Users.Include(u => u.CreditCards).FirstOrDefault(u => u.UserName == userName);
                        if (user == null)
                        {
                            if (HandleRetry($"User {userName} was not found."))
                                return;
                            continue;
                        }
                        if (user.IsActive == false)
                        {
                            if (HandleRetry($"User {userName} is not active."))
                                return;
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        ShowOrderingProduct();
                        Console.WriteLine("Enter Product Quantity:");
                        if (!int.TryParse(Console.ReadLine(), out productQuantity) || productQuantity <= 0)
                        {
                            if (HandleRetry("Invalid quantity. Quantity must be a positive number."))
                                return;
                            continue;
                        }
                        else if (productQuantity > foundProduct.ProductQuantity)
                        {
                            if (HandleRetry($"Ordered quantity exceeds available quantity. Available: {foundProduct.ProductQuantity}"))
                                return;
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        ShowOrderingProduct();
                        Console.WriteLine("Choose a Credit Card:");
                        if (user.CreditCards == null || user.CreditCards.Count == 0)
                        {
                            Clear();
                            LineLong();
                            Console.WriteLine($"User {user.UserName} Does not have any Credit Card!");
                            LineLong();
                            return;
                        }
                        LineLong();
                        foreach (var card in user.CreditCards)
                        {
                            Console.WriteLine($"Card ID: {card.Id}, Balance: {card.CreditCardBalance:C}, Holder Name: {card.CreditCardHolderName}, CVV: {card.CreditCardCVV}");
                        }
                        LineLong();
                        Console.WriteLine("Enter the Credit Card ID:");
                        if (!int.TryParse(Console.ReadLine(), out int selectedCardId))
                        {
                            if (HandleRetry("Invalid card ID. Please try again."))
                                return;
                            continue;
                        }
                        selectedCard = user.CreditCards.FirstOrDefault(c => c.Id == selectedCardId);
                        if (selectedCard == null)
                        {
                            if (HandleRetry("Selected card ID was not found. Please try again."))
                                return;
                            continue;
                        }
                        decimal productTotal = productQuantity * foundProduct.ProductPrice;
                        decimal courierFee = user.HasWoltPlus ? 0 : new Random().Next(3, 15);
                        decimal totalAmount = productTotal + courierFee;
                        if (selectedCard.CreditCardBalance < totalAmount)
                        {
                            if (HandleRetry($"Insufficient balance. Required: {totalAmount:C}, Available: {selectedCard.CreditCardBalance:C}"))
                                return;
                            continue;
                        }
                        break;
                    }                
                    try
                    {
                        decimal productTotal = productQuantity * foundProduct.ProductPrice;
                        decimal courierFee = user.HasWoltPlus ? 0 : new Random().Next(3, 15);
                        decimal totalAmount = productTotal + courierFee;
                        Order newOrder = new Order
                        {
                            UserId = user.Id,
                            RestaurantId = foundProduct.RestaurantsId,
                            OrderStatus = ORDER_ENUM.PENDING.ToString(),
                            OrderItems = new List<OrderItem>()
                        };
                        var orderValidator = new OrderValidator();
                        var orderValidationResult = orderValidator.Validate(newOrder);
                        if (!orderValidationResult.IsValid)
                        {
                            Clear();
                            LineLong();
                            Console.WriteLine("Order validation failed:");
                            foreach (var error in orderValidationResult.Errors)
                            {
                                Console.WriteLine($"- {error.ErrorMessage}");
                            }
                            LineLong();
                            Console.ReadKey();
                            return;
                        }
                        _context.Orders.Add(newOrder);
                        _context.SaveChanges();
                        OrderItem newOrderItem = new OrderItem
                        {
                            OrderId = newOrder.Id,
                            ProductId = foundProduct.Id,
                            TotalPrice = productTotal,
                            Quantity = productQuantity,
                            OrderDate = DateTime.Now
                        };
                        var orderItemValidator = new OrderItemValidator();
                        var orderItemValidationResult = orderItemValidator.Validate(newOrderItem);
                        if (!orderItemValidationResult.IsValid)
                        {
                            Clear();
                            LineLong();
                            Console.WriteLine("Order item validation failed:");
                            foreach (var error in orderItemValidationResult.Errors)
                            {
                                Console.WriteLine($"- {error.ErrorMessage}");
                            }
                            LineLong();
                            _context.Orders.Remove(newOrder);
                            _context.SaveChanges();
                            return;
                        }
                        newOrder.OrderItems.Add(newOrderItem);
                        _context.OrderItems.Add(newOrderItem);
                        _context.SaveChanges();
                        Payment newPayment = new Payment
                        {
                            OrderId = newOrder.Id,
                            UserId = user.Id,
                            CreditCardId = selectedCard.Id,
                            TotalAmount = totalAmount,
                            PaymentStatus = PAYMENT_ENUM.COMPLETED.ToString(),
                        };
                        var paymentValidator = new PaymentValidator();
                        var paymentValidationResult = paymentValidator.Validate(newPayment);
                        if (!paymentValidationResult.IsValid)
                        {
                            Clear();
                            LineLong();
                            Console.WriteLine("Payment validation failed:");
                            foreach (var error in paymentValidationResult.Errors)
                            {
                                Console.WriteLine($"- {error.ErrorMessage}");
                            }
                            LineLong();
                            _context.OrderItems.Remove(newOrderItem);
                            _context.Orders.Remove(newOrder);
                            _context.SaveChanges();
                            return;
                        }

                        _context.Payments.Add(newPayment);
                        _context.SaveChanges();
                        selectedCard.CreditCardBalance -= totalAmount;
                        var restaurant = _context.Restaurants.Find(foundProduct.RestaurantsId);
                        restaurant.RestaurantBalance += totalAmount;
                        foundProduct.ProductQuantity -= productQuantity;

                        _context.SaveChanges();
                        Clear();
                        LineLong();
                        Console.WriteLine("Order placed successfully!");
                        LineLong();
                        Console.WriteLine($"Product Total: {productTotal}");
                        Console.WriteLine($"Total Amount: {totalAmount}$ (Courier Fee: {courierFee}$)");
                        Console.WriteLine($"Credit Card New Balance {selectedCard.CreditCardBalance}$");
                        Console.WriteLine($"Restaurant New Balance {restaurant.RestaurantBalance}$");
                        LineLong();
                        // add order status logic
                        // add if product has multiple restaurants
                        // add file sending
                    }
                    catch (Exception ex)
                    {
                        Clear();
                        LineLong();
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        LineLong();
                    }
                }

                HandleUserInput();
            }
            /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT
            /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT  /// ORDER PRODUCT
            else
            {
                Line();
                Console.WriteLine($"Product {productChoice} ID Or Name Was Not Found");
                Line();
            }
             break;
        }
    }
}