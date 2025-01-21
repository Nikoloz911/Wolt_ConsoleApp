﻿using BCrypt.Net;
using Twilio.Types;
using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Models;
using Wolt_ConsoleApp.Twilio;

namespace Wolt_ConsoleApp.Functions.UserFunctions;
internal class SingUp
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

    public static void UserSignUp()
    {
        DataContext _context = new DataContext();
        bool Registered = false;
        while (!Registered)
        {
            bool IsValidUserName = false;
            bool IsValidUserLastName = false;
            bool IsValidUserEmail = false;
            bool IsValidUserAddress = false;
            bool IsValidUserPhoneNumber = false;
            bool IsValidPassword = false;
            bool IsValidConfirmCode = false;

            /// START REGISTRATION  /// START REGISTRATION
            /// FIRST NAME INPUT /// FIRST NAME INPUT
            while (!IsValidUserName)
            {
                Clear();
                Console.WriteLine("Enter User First Name:");
                string FirstName = Console.ReadLine();
                if (FirstName == "")
                {
                    Clear();
                    Line();
                    Console.WriteLine("First Name Can not Be Empty!");
                    Line();
                    Console.WriteLine("1. Try Again");
                    Console.WriteLine("2. Exit Registartion");
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
                /// FIRST NAME INPUT /// FIRST NAME INPUT
                /// LASTNAME INPUT /// LASTNAME INPUT  /// LASTNAME INPUT
                while (!IsValidUserLastName)
                {
                    Clear();
                    Console.WriteLine("Enter User Last Name:");
                    string LastName = Console.ReadLine();
                    if (LastName == "")
                    {
                        Clear();
                        Line();
                        Console.WriteLine("Last Name Can not Be Empty!");
                        Line();
                        Console.WriteLine("1. Try Again");
                        Console.WriteLine("2. Exit Registartion");
                        string LastNamechoice = Console.ReadLine();
                        if (LastNamechoice == "1")
                        {
                            continue;
                        }
                        else if (LastNamechoice == "2")
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
                    /// LASTNAME INPUT /// LASTNAME INPUT  /// LASTNAME INPUT
                    /// EMAIL INPUT /// EMAIL INPUT  /// EMAIL INPUT
                    while (!IsValidUserEmail)
                    {
                        Clear();
                        Console.WriteLine("Enter User Email:");
                        string Email = Console.ReadLine();
                        if (Email == "")
                        {
                            Clear();
                            Line();
                            Console.WriteLine("Email Can not Be Empty!");
                            Line();
                            Console.WriteLine("1. Try Again");
                            Console.WriteLine("2. Exit Registartion");
                            string Emailchoice = Console.ReadLine();
                            if (Emailchoice == "1")
                            {
                                continue;
                            }
                            else if (Emailchoice == "2")
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
                        else if (!Email.Contains("@") || !Email.Contains("gmail") || !Email.EndsWith(".com"))
                        {
                            Clear();
                            Line();
                            Console.WriteLine("Invalid Email Format!");
                            Line();
                            Console.WriteLine("1. Try Again");
                            Console.WriteLine("2. Exit Registration");
                            string EmailChoice = Console.ReadLine();
                            if (EmailChoice == "1")
                            {
                                continue;
                            }
                            else if (EmailChoice == "2")
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
                        /// EMAIL INPUT /// EMAIL INPUT  /// EMAIL INPUT
                        /// ADDRESS INPUT /// ADDRESS INPUT  /// ADDRESS INPUT
                        while (!IsValidUserAddress)
                        {
                            Clear();
                            Console.WriteLine("Enter User Address:");
                            string Address = Console.ReadLine();
                            if (Address == "")
                            {
                                Clear();
                                Line();
                                Console.WriteLine("Address Can not Be Empty!");
                                Line();
                                Console.WriteLine("1. Try Again");
                                Console.WriteLine("2. Exit Registartion");
                                string Emailchoice = Console.ReadLine();
                                if (Emailchoice == "1")
                                {
                                    continue;
                                }
                                else if (Emailchoice == "2")
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
                            /// ADDRESS INPUT /// ADDRESS INPUT  /// ADDRESS INPUT
                            /// PHONE NUMBER INPUT /// PHONE NUMBER INPUT
                            while (!IsValidUserPhoneNumber)
                            {
                                Clear();
                                Console.WriteLine("Enter User Phone Number:");
                                string PhoneNumber = Console.ReadLine();
                                if (PhoneNumber == "")
                                {
                                    Clear();
                                    Line();
                                    Console.WriteLine("Phone Number Can not Be Empty!");
                                    Line();
                                    Console.WriteLine("1. Try Again");
                                    Console.WriteLine("2. Exit Registartion");
                                    string PhoneNumberchoice = Console.ReadLine();
                                    if (PhoneNumberchoice == "1")
                                    {
                                        continue;
                                    }
                                    else if (PhoneNumberchoice == "2")
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
                                else if (PhoneNumber.Length != 9 || !PhoneNumber.All(char.IsDigit))
                                {
                                    Clear();
                                    Line();
                                    Console.WriteLine("Invalid Phone Number Format!");
                                    Line();
                                    Console.WriteLine("1. Try Again");
                                    Console.WriteLine("2. Exit Registration");
                                    string PhoneChoice = Console.ReadLine();
                                    if (PhoneChoice == "1")
                                    {
                                        continue;
                                    }
                                    else if (PhoneChoice == "2")
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
                                /// PHONE NUMBER INPUT /// PHONE NUMBER INPUT
                                /// CONFIRM CODE INPUT /// CONFIRM CODE INPUT
                                while (!IsValidConfirmCode)
                                {
                                    Clear();
                                    ///// TWILIO SERVICE
                                    //if (!PhoneNumber.StartsWith("995"))
                                    //{
                                    //    PhoneNumber = "995" + PhoneNumber;
                                    //}
                                    //PhoneNumber = "+" + PhoneNumber;
                                    //var twilioService = new TwilioService();
                                    //string sentCode = twilioService.SendVerificationCode(PhoneNumber);
                                    ////// TWILIO SERVICE
                                    Console.WriteLine("Enter Verification Code:");
                                    string ConfirmCode = Console.ReadLine();
                                    //if (ConfirmCode == sentCode)
                                    //{
                                    //}
                                    //else
                                    //{
                                    //    Clear();
                                    //    Line();
                                    //    Console.WriteLine("Verification Code Was Inccorect");
                                    //    Line();
                                    //    Console.WriteLine("1. Try Again");
                                    //    Console.WriteLine("2. Exit Registration");
                                    //    string retryCodeChoice = Console.ReadLine();
                                    //    if (retryCodeChoice == "1")
                                    //    {
                                    //        continue;
                                    //    }
                                    //    else if (retryCodeChoice == "2")
                                    //    {
                                    //        Clear();
                                    //        return;
                                    //    }
                                    //    else
                                    //    {
                                    //        InvalidChoice(); 
                                    //        return;
                                    //    }
                                    //}
                                    /// CONFIRM CODE INPUT /// CONFIRM CODE INPUT
                                    /// PASSWORD INPUT   /// PASSWORD INPUT
                                    while (!IsValidPassword)
                                    {
                                        Clear();
                                        Console.WriteLine("Make User Password:");
                                        string passwordInput = "";
                                        while (true)
                                        {
                                            var key = Console.ReadKey(true); 
                                            if (key.Key == ConsoleKey.Enter) break; 
                                            if (key.Key == ConsoleKey.Backspace && passwordInput.Length > 0)
                                            {
                                                passwordInput = passwordInput.Substring(0, passwordInput.Length - 1); // Remove last character
                                                Console.Write("\b \b");
                                            }
                                            else
                                            {
                                                passwordInput += key.KeyChar;
                                                Console.Write("*"); 
                                            }
                                        }
                                      
                                       
                                      
                                        Clear();
                                        Line();
                                        Console.WriteLine("Registration Successful!");
                                        Line();
                                      
                                    }
                                }
                            }
                        }
                    }
                }
            }
            /// END REGISTRATION  /// END REGISTRATION
        }
    }

}
