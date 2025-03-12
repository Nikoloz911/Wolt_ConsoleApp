using Wolt_ConsoleApp.Functions.SystemFunctions;
namespace Wolt_ConsoleApp.Functions;
internal class SystemFunction
{
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static void ColorLine(string text, ConsoleColor color)
    { Console.ForegroundColor = color; Console.WriteLine(text); Console.ResetColor(); }
    public static void SystemVoid()
    {
        Clear();
        ColorLine("1. Show System Information", ConsoleColor.Green);
        ColorLine("2. Show Usings", ConsoleColor.Yellow);
        ColorLine("3. Show System Log", ConsoleColor.Cyan);
        ColorLine("4. Show Projects Details", ConsoleColor.Blue);
        string choice = Console.ReadLine();
        Clear();
        if (choice == "1")
        {
            SystemInfo.ViewSystemInformation();
        }
        else if(choice == "2")
        {
            Line();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("using Wolt_ConsoleApp.Data");
            Console.WriteLine("using Wolt_ConsoleApp.Functions;");
            Console.WriteLine("using Wolt_ConsoleApp.Models;");
            Console.WriteLine("using Wolt_ConsoleApp.Enums"); 
            Console.WriteLine("using Wolt_ConsoleApp.Validators");
            Console.WriteLine("using Wolt_ConsoleApp.SMTP;");
            Console.WriteLine("using Wolt_ConsoleApp.Twilio;");
            Console.WriteLine("using Wolt_ConsoleApp.Functions.SystemFunctions;");
            Console.WriteLine("using Wolt_ConsoleApp.Functions.UserFunctions;");    
            Console.WriteLine("using Wolt_ConsoleApp.Functions.DataFunctions;");
            Console.WriteLine("using Twilio.Types;");
            Console.WriteLine("using Twilio.Rest.Api.V2010.Account;");
            Console.WriteLine("using System.Net.Mail;");
            Console.WriteLine("using System.Net;");
            Console.WriteLine("using System.Management;");
            Console.WriteLine("using System.Text;");
            Console.WriteLine("using System.Text.RegularExpressions;");
            Console.WriteLine("using System.Globalization;");
            Console.WriteLine("using PdfSharpCore.Drawing;");
            Console.WriteLine("using PdfSharpCore.Pdf;");
            Console.WriteLine("using BCrypt.Net;");
            Console.WriteLine("using FluentValidation;");
            Console.WriteLine("using Microsoft.EntityFrameworkCore;");
            Console.ResetColor();
            Line();
            Console.ReadKey();
            Clear();
        }
        else if (choice == "3")
        {
            ReadAllFiles();
        }
        else if (choice == "4")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Line();
            Console.WriteLine("Total Folders : 12");
            Console.WriteLine("Total Classes : 50");
            Console.WriteLine("Functions Classes : 24");
            Console.WriteLine("Validators : 7");
            Console.WriteLine("Models : 8");
            Console.WriteLine("Data : 3");
            Console.WriteLine("Enums : 2");
            Console.WriteLine("SMTP : 2");
            Console.WriteLine("Twilio : 1");
            Console.WriteLine("Interfaces : 0");
            Line();
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Line();
            Console.WriteLine("Invalid choice!");
            Line();
            Console.ResetColor();
        }
    }
    public static void ReadAllFiles()
    {
        Clear();

        // Read User file
        string userFilePath = "User.txt";
        Console.WriteLine("                                                --- User File Content ---                                                ");
        if (File.Exists(userFilePath))
        {
            using (StreamReader reader = new StreamReader(userFilePath))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine(fileContent);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Line();
            Console.WriteLine("User file not found.");
            Line();
            Console.ResetColor();
        }

        // Read Products file
        string productsFilePath = "Products.txt";
        Console.WriteLine("                                                --- Products File Content ---                                                ");
        if (File.Exists(productsFilePath))
        {
            using (StreamReader reader = new StreamReader(productsFilePath))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine(fileContent);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Line();
            Console.WriteLine("Products file not found.");
            Line();
            Console.ResetColor();
        }

        // Read Restaurants file
        string restaurantsFilePath = "Restaurants.txt";
        Console.WriteLine("                                                --- Restaurants File Content ---                                                ");
        if (File.Exists(restaurantsFilePath))
        {
            using (StreamReader reader = new StreamReader(restaurantsFilePath))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine(fileContent);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Line();
            Console.WriteLine("Restaurants file not found.");
            Line();
            Console.ResetColor();
        }

        // Read Orders file
        string ordersFilePath = "Orders.txt";
        Console.WriteLine("                                                --- Orders File Content ---                                                ");
        if (File.Exists(ordersFilePath))
        {
            using (StreamReader reader = new StreamReader(ordersFilePath))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine(fileContent);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Line();
            Console.WriteLine("Orders file not found.");
            Line();
            Console.ResetColor();
        }
    }
}
