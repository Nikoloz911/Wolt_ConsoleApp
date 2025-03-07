namespace Wolt_ConsoleApp.Functions;
internal class FileManagement
{
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static void FileManagementVoid()
    {
        Clear();
        Console.WriteLine("1. Read User File");
        Console.WriteLine("2. Read Products File");
        Console.WriteLine("3. Read Restaurants File");
        Console.WriteLine("4. Read Orders File");
        string choice = Console.ReadLine();
        Clear();
        if(choice == "1")
        {
            ReadUserFile();
        }
        else if(choice == "2")
        {
            ReadProductsFile(); 
        }
        else if (choice == "3")
        {
            ReadRestaurantsFile();
        }
        else if (choice == "4")
        {
            ReadOrdersFile();
        }
        else
        {
            Line();
            Console.WriteLine("Invalid choice!");
            Line();
        }
    }

    /// USER FILE READ TO END   /// USER FILE READ TO END   /// USER FILE READ TO END
    public static void ReadUserFile()
    {   
        string filePath = "User.txt";
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine("                                                --- User File Content ---                                                ");
                Console.WriteLine();
                Console.WriteLine(fileContent);
            }
        }
        else
        {
            Line();
            Console.WriteLine("User file not found.");
            Line();
        }
    }
    /// USER FILE READ TO END   /// USER FILE READ TO END   /// USER FILE READ TO END
    /// PRODUCTS FILE READ TO END    /// PRODUCTS FILE READ TO END
    public static void ReadProductsFile()
    {
        string filePath = "Products.txt";
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine("                                                --- Products File Content ---                                                ");
                Console.WriteLine();
                Console.WriteLine(fileContent);
            }
        }
        else
        {
            Line();
            Console.WriteLine("Products file not found.");
            Line();
        }
    }
    /// PRODUCTS FILE READ TO END    /// PRODUCTS FILE READ TO END
    /// RESTAURANTS FILE READ TO END   /// RESTAURANTS FILE READ TO END
    public static void ReadRestaurantsFile()
    {
        string filePath = "Restaurants.txt";
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine("                                                --- Restaurants File Content ---                                                ");
                Console.WriteLine();
                Console.WriteLine(fileContent);
            }
        }
        else
        {
            Line();
            Console.WriteLine("Restaurants file not found.");
            Line();
        }
    }
    /// RESTAURANTS FILE READ TO END   /// RESTAURANTS FILE READ TO END
    /// ORDERS FILE READ TO END   /// ORDERS FILE READ TO END
    public static void ReadOrdersFile()
    {
        string filePath = "Orders.txt";
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine("                                                --- Orders File Content ---                                                ");
                Console.WriteLine();
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
    /// ORDERS FILE READ TO END   /// ORDERS FILE READ TO END
}