using Wolt_ConsoleApp.Functions.SystemFunctions;
namespace Wolt_ConsoleApp.Functions;
internal class SystemFunction
{
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static void SystemVoid()
    {
        Clear();    
        Console.WriteLine("1. Show System Information");
        Console.WriteLine("2. Show Usings");
        Console.WriteLine("3. Show System Log");
        Console.WriteLine("4. Show Projects Details");
        string choice = Console.ReadLine();
        Clear();
        if (choice == "1")
        {
            SystemInfo.ViewSystemInformation();
        }
        else if(choice == "2")
        {
            Console.WriteLine("");
        }
        else if (choice == "3")
        {
            ReadAllFiles();
        }
        else if (choice == "4")
        {
            Console.WriteLine("");

            // Total Classes : 47
            // Functions Classes : 24
            // Validators : 7
            // Models : 8
            // Data : 3
            // Enums : 2
            // SMTP : 2
            // Twilio : 1
            // Interfaces : 0
        }
        else
        {
            Line();
            Console.WriteLine("Invalid choice!");
            Line();
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
            Line();
            Console.WriteLine("User file not found.");
            Line();
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
            Line();
            Console.WriteLine("Products file not found.");
            Line();
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
            Line();
            Console.WriteLine("Restaurants file not found.");
            Line();
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
            Line();
            Console.WriteLine("Orders file not found.");
            Line();
        }
    }
}
