using Microsoft.EntityFrameworkCore;
using Wolt_ConsoleApp.Data;
namespace Wolt_ConsoleApp.Functions.UserFunctions;
internal class WoltPlus
{
    public static void Clear()
    {
        Console.Clear();
    }
    public static void InvalidChoice()
    {
        Clear();
        Line();
        Console.WriteLine("Invalid choice!");
        Line();
    }
    public static int Line()
    {
        int length = 55;
        string dashLine = new string('-', length);
        Console.WriteLine(dashLine);
        return length;
    }
    public static void PurchaseWoltPlus()
    {
        DataContext _context = new DataContext();
        Clear();
        bool isAddedWoltPlus = false;
        while (!isAddedWoltPlus)
        {
            Console.WriteLine("Enter User Name: ");
            string username = Console.ReadLine();
            if (string.IsNullOrEmpty(username))
            {
                if (!RetryOption("User Name Cannot Be Empty!"))
                    return; 
                continue;
            }
            var user = _context.Users
                .Include(u => u.CreditCards) 
                .FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                if (!RetryOption("No user found with the entered username."))
                    return; 
                continue;
            }
            if (user.CreditCards == null || !user.CreditCards.Any())
            {
                if (!RetryOption("The user has no credit cards."))
                    return;
                continue;
            }
            if (user.HasWoltPlus)
            {
                Clear();
                Line();
                Console.WriteLine("This user already has WoltPlus.");
                Line();
                return;
            }
            Clear();
            Line();
            Console.WriteLine($"User: {user.UserName}");
            Console.WriteLine("Available Credit Cards:");
            foreach (var card in user.CreditCards)
            {
                string maskedCardNumber = new string('*', card.CreditCardNumber.Length - 4) + card.CreditCardNumber[^4..];
                Console.WriteLine($"ID: {card.Id}, Number: {maskedCardNumber}, Balance: {card.CreditCardBalance}");
            }
            Line();
            bool validCardSelected = false;
            while (!validCardSelected)
            {
                Console.WriteLine("Enter the Credit Card ID to use: ");
                string cardIdInput = Console.ReadLine();
                if (!int.TryParse(cardIdInput, out int cardId))
                {
                    if (!RetryOption("Invalid Credit Card ID!"))
                        return; 
                    continue; 
                }
                var selectedCard = user.CreditCards.FirstOrDefault(c => c.Id == cardId);
                if (selectedCard == null)
                {
                    if (!RetryOption("Credit Card not found!"))
                        return; 
                    continue; 
                }
                if (selectedCard.CreditCardBalance < 10)
                {
                    if (!RetryOption("Insufficient balance on the selected credit card. The purchase cannot be completed."))
                        return;
                    continue; 
                }
                selectedCard.CreditCardBalance -= 10;
                user.HasWoltPlus = true;
                _context.SaveChanges();
                Clear();
                Line();
                Console.WriteLine("WoltPlus has been successfully purchased!");
                Line();
                Console.WriteLine($"Remaining Balance on Credit Card: {selectedCard.CreditCardBalance}");
                Line();
                validCardSelected = true;
                isAddedWoltPlus = true;
                // Write In File
                string purchaseData = $"User: {user.UserName} {user.UserLastName} purchased WoltPlus at {DateTime.Now}";
                UserManagement.WriteToFile(purchaseData);
            }
        }
    }
    private static bool RetryOption(string errorMessage)
    {
        Clear();
        Line();
        Console.WriteLine(errorMessage);
        Line();
        Console.WriteLine("1. Try Again");
        Console.WriteLine("2. Exit");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Clear(); 
            return true; 
        }
        else if (choice == "2")
        {
            Clear(); 
            return false; 
        }
        else
        {
            InvalidChoice();
            return false; 
        }
    }
}
