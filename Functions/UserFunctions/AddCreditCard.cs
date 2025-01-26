﻿
using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Models;
namespace Wolt_ConsoleApp.Functions.UserFunctions
{
    internal class AddCreditCard
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
        public static void AddUserCreditCard()
        {
            DataContext _context = new DataContext();
            bool IsAddedCreditCard = false;
            while (!IsAddedCreditCard)
            {
                bool IsValidUserId = false;
                while (!IsValidUserId)
                {
                    Clear();
                    Line();
                    var users = _context.Users.OrderBy(u => u.Id);
                    foreach (var user in users)
                    {
                        Console.WriteLine($"ID: {user.Id}, Name: {user.UserName}");
                    }
                    Line();
                    Console.WriteLine("Enter your User ID: ");
                    string UserId = Console.ReadLine();

                    if (UserId == "")
                    {
                        Clear();
                        Line();
                        Console.WriteLine("User ID Cannot Be Empty!");
                        Line();
                        Console.WriteLine("1. Try Again");
                        Console.WriteLine("2. Exit Adding CreditCard");
                        string FirstNamechoice = Console.ReadLine();
                        if (FirstNamechoice == "1")
                        {
                            continue;
                        }
                        else if (FirstNamechoice == "2")
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
                    else
                    {
                        var user = _context.Users.FirstOrDefault(u => u.Id.ToString() == UserId);
                        if (user == null)
                        {
                            Clear();
                            Line();
                            Console.WriteLine("User ID is Incorrect!");
                            Line();
                            Console.WriteLine("1. Try Again");
                            Console.WriteLine("2. Exit Adding CreditCard");
                            string FirstNamechoice = Console.ReadLine();
                            if (FirstNamechoice == "1")
                            {
                                continue;
                            }
                            else if (FirstNamechoice == "2")
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
                        /// ADDING CREDIT CARD /// ADDING CREDIT CARD  /// ADDING CREDIT CARD  
                        else
                        {
                            bool IsValidHolderName = false;
                            bool IsValidCreditCardNumber = false;
                            bool IsValidExpiryDate = false;
                            bool IsValidCVV = false;
                            bool IsValidBalance = false;
                            while (!IsValidHolderName)
                            {
                                Clear();
                                Console.WriteLine("Enter Credit Card Holder Name");
                                string UserCreditCardHolderName = Console.ReadLine();
                                if(UserCreditCardHolderName == "")
                                {
                                    Clear();
                                    Line();
                                    Console.WriteLine("Credit Card Holder Name Cannot Be Empty!");
                                    Line();
                                    Console.WriteLine("1. Try Again");
                                    Console.WriteLine("2. Exit Adding CreditCard");
                                    string CreditCardChoice = Console.ReadLine();
                                    if (CreditCardChoice == "1")
                                    {
                                        continue;
                                    }
                                    else if (CreditCardChoice == "2")
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
                                while (!IsValidCreditCardNumber)
                                {
                                    Clear();
                                    Console.WriteLine("Enter Credit Card Number");
                                    string UserCreditCardNumber = "";
                                    int charCount = 0;  // To track every 4 digits
                                    while (charCount < 16)
                                    {
                                        // Read user input
                                        string input = Console.ReadKey(true).KeyChar.ToString();
                                        // Only allow numeric input
                                        if (char.IsDigit(input[0]))
                                        {
                                            UserCreditCardNumber += input;
                                            charCount++;
                                            // Display the input with a space every 4 digits
                                            Console.Clear();
                                            Console.WriteLine("Enter Credit Card Number");
                                            // Format with space after every 4 digits for display
                                            for (int i = 0; i < UserCreditCardNumber.Length; i++)
                                            {
                                                Console.Write(UserCreditCardNumber[i]);
                                                if ((i + 1) % 4 == 0 && i != UserCreditCardNumber.Length - 1)
                                                {
                                                    Console.Write(" ");  // Add space after every 4th digit
                                                }
                                            }
                                        }
                                    }
                                    Console.WriteLine();  // Move to the next line after input is completed
                                    // Remove any spaces from the entered card number before saving
                                    UserCreditCardNumber = UserCreditCardNumber.Replace(" ", "");
                                    if (UserCreditCardNumber == "")
                                    {
                                        Clear();
                                        Line();
                                        Console.WriteLine("Credit Card Number Cannot Be Empty!");
                                        Line();
                                        Console.WriteLine("1. Try Again");
                                        Console.WriteLine("2. Exit Adding CreditCard");
                                        string CreditCardChoice = Console.ReadLine();
                                        if (CreditCardChoice == "1")
                                        {
                                            continue;
                                        }
                                        else if (CreditCardChoice == "2")
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
                                    while (!IsValidExpiryDate)
                                    {
                                        Clear();
                                        Console.WriteLine("Enter Credit Card Expiry Date (MM/dd/yyyy)");
                                        string UserCreditCardExpiryDate = Console.ReadLine();
                                        while (!IsValidCVV)
                                        {
                                            Clear();
                                            Console.WriteLine("Enter Credit Card CVV");
                                            string UserCreditCardCVV = Console.ReadLine();
                                            while (!IsValidBalance)
                                            {
                                                Clear();
                                                Console.WriteLine("Enter Credit Card Balance");
                                                string UserCreditCardBalance = Console.ReadLine();

                                                CreditCard creditCard = new CreditCard
                                                {
                                                    UserId = user.Id,
                                                    CreditCardHolderName = UserCreditCardHolderName,
                                                    CreditCardNumber = UserCreditCardNumber,
                                                    CreditCardExpiryDate = DateTime.Parse(UserCreditCardExpiryDate),
                                                    CreditCardCVV = UserCreditCardCVV,
                                                    CreditCardBalance = decimal.Parse(UserCreditCardBalance)
                                                };
                                                _context.CreditCards.Add(creditCard);
                                                _context.SaveChanges();
                                                Clear();
                                                Line();
                                                Console.WriteLine("Credit Card Added Successfully!");
                                                Line();
                                                IsValidHolderName = true;
                                                IsValidCreditCardNumber = true;
                                                IsValidExpiryDate = true;
                                                IsValidCVV = true;
                                                IsValidBalance = true;
                                                ///
                                                IsValidUserId = true;
                                                IsAddedCreditCard = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        /// ADDING CREDIT CARD /// ADDING CREDIT CARD  /// ADDING CREDIT CARD  
                    }
                }
            }
        }
    }
}
