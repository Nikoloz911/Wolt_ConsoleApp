﻿using Wolt_ConsoleApp.Data;
using BCrypt.Net;
namespace Wolt_ConsoleApp.Functions.UserFunctions;
internal class LogOut
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
    public static void InvalidChoice()
    {
        Clear();
        Line();
        Console.WriteLine("Invalid choice!");
        Line();
    }
    public static void UserLogOut()
    {
        DataContext _context = new DataContext();
        bool isLoggedIn = false;
        while (!isLoggedIn)
        {
            bool isValidUserName = false;
            string userName = string.Empty;
            while (!isValidUserName)
            {
                Clear();
                Console.WriteLine("Enter your Username:");
                userName = Console.ReadLine();
                if (string.IsNullOrEmpty(userName))
                {
                    Clear();
                    Line();
                    Console.WriteLine("Username cannot be empty!");
                    Line();
                    Console.WriteLine("1. Try Again");
                    Console.WriteLine("2. Exit Log In");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        continue;
                    }
                    else if (choice == "2")
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
                var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
                if (user != null)
                {
                    Clear();
                    Line();
                    Console.WriteLine($"Username '{userName}' found!");
                    Line();
                    isValidUserName = true;
                }
                else
                {
                    Clear();
                    Line();
                    Console.WriteLine("User does not exist.");
                    Line();
                    Console.WriteLine("1. Try Again");
                    Console.WriteLine("2. Exit Log In");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        continue;
                    }
                    else if (choice == "2")
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
            bool isValidPassword = false;
            while (!isValidPassword)
            {
                Clear();
                Console.WriteLine("Enter your Password:");
                string password = Console.ReadLine();
                if (string.IsNullOrEmpty(password))
                {
                    Clear();
                    Line();
                    Console.WriteLine("Password cannot be empty!");
                    Line();
                    Console.WriteLine("1. Try Again");
                    Console.WriteLine("2. Exit Log In");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        continue;
                    }
                    else if (choice == "2")
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
                var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.UserPassword))
                {
                    Clear();
                    Line();
                    Console.WriteLine($"User: {userName} Logged Out Successfully!");
                    Line();
                    user.IsActive = false;
                    isValidPassword = true;
                    isLoggedIn = true; // NOT TRUE. just exits loops
                    _context.SaveChanges();
                    // Write In File
                    string logoutData = $"User: {user.UserName} {user.UserLastName} logged out at {DateTime.Now}";
                    UserManagement.WriteToFile(logoutData);
                }

                else
                {
                    Clear();
                    Line();
                    Console.WriteLine("Incorrect password.");
                    Line();
                    Console.WriteLine("1. Try Again");
                    Console.WriteLine("2. Exit Log In");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        continue;
                    }
                    else if (choice == "2")
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
        }
    }
}
