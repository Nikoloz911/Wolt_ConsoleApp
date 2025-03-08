using Wolt_ConsoleApp.Data;
namespace Wolt_ConsoleApp.Functions.UserFunctions;
internal class AddBalance
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
    public static void InvalidChoice()
    {
        Clear();
        Line();
        Console.WriteLine("Invalid choice!");
        Line();
    }
    public static void AddBalanceToCreditCard()
    {
        Clear();
        DataContext _context = new DataContext();

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
            int cardCounter = 1;
            foreach (var card in creditCardInfo)
            {
                string fullCardNumber = card.CreditCardNumber;
                string last4Digits = fullCardNumber.Length >= 4 ? fullCardNumber.Substring(fullCardNumber.Length - 4) : fullCardNumber;
                Console.WriteLine($"{cardCounter}. User Name: {card.UserName}, Card Number: **** **** **** {last4Digits}, Expiry Date: {card.ExpiryDate}, Balance: {card.Balance}");
                cardCounter++;
            }
            LineLong();
            Console.WriteLine();
            Console.Write("Enter the number of the credit card to add balance: ");
            string input = Console.ReadLine();
            int selectedCardNumber;
            while (!int.TryParse(input, out selectedCardNumber) || selectedCardNumber <= 0 || selectedCardNumber > creditCardInfo.Count())
            {
                Clear();
                Line();
                Console.WriteLine("Invalid input!");
                Line();
                return;
            }
            var selectedCard = creditCardInfo.ElementAtOrDefault(selectedCardNumber - 1);
            if (selectedCard != null)
            {
                bool isValidBalance = false;
                decimal balanceToAdd = 0;

                while (!isValidBalance)
                {
                    Clear();
                    Console.Write("Enter the balance amount to add: ");
                    string userInput = Console.ReadLine();
                    if (decimal.TryParse(userInput, out balanceToAdd) && balanceToAdd > 0)
                    {
                        isValidBalance = true;
                    }
                    else
                    {
                        Clear();
                        Line();
                        Console.WriteLine("Invalid input! Please enter a valid amount greater than 0.");
                        Line();
                        Console.WriteLine("1. Try Again");
                        Console.WriteLine("2. Exit Adding Balance");
                        string retryChoice = Console.ReadLine().ToLower();
                        if (retryChoice == "1")
                        {
                            continue;
                        }
                        else if (retryChoice == "2")
                        {
                            Clear();
                            return;
                        }
                        else
                        {
                            InvalidChoice();
                            return;
                        }
                    }
                }
                if (isValidBalance)
                {
                    var cardToUpdate = _context.CreditCards.SingleOrDefault(c => c.CreditCardNumber == selectedCard.CreditCardNumber);
                    if (cardToUpdate != null)
                    {
                        decimal oldBalance = cardToUpdate.CreditCardBalance;
                        cardToUpdate.CreditCardBalance += balanceToAdd;
                        _context.SaveChanges();
                        Clear();
                        Line();
                        Console.WriteLine($"Successfully added {balanceToAdd} to {selectedCard.UserName}'s card. New balance: {cardToUpdate.CreditCardBalance}");
                        Line();
                        // Write In File
                        string balanceData = $"User: {selectedCard.UserName} added {balanceToAdd} to Credit Card, Old Balance: {oldBalance}, New Balance: {cardToUpdate.CreditCardBalance} at {DateTime.Now}";
                        UserManagement.WriteToFile(balanceData);
                    }

                }
            }
            else
            {
                Clear();
                Line();
                Console.WriteLine("Invalid card selection.");
                Line();
            }
        }
        else
        {
            Clear();
            Line();
            Console.WriteLine("No credit cards found.");
            Line();
        }
    }
}
