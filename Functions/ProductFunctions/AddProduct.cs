using Wolt_ConsoleApp.Data;
namespace Wolt_ConsoleApp.Functions.ProductFunctions;
internal class AddProduct
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
    public static void AddProductToRestaurant()
    {
        bool IsProductAdded = false;
        while (!IsProductAdded)
        {
            bool IsValidName = false;
            while (!IsValidName)
            {
                Clear();
                Console.WriteLine("Enter Product Name:");
                string ProductName = Console.ReadLine();
                bool IsValidPrice = false;
                while(!IsValidPrice)
                {
                    Clear();
                    Console.WriteLine("Enter Product Price:");
                    string ProductPrice = Console.ReadLine();
                    bool IsvalidAvailable = false;
                    while (!IsvalidAvailable)
                    {

                        Console.WriteLine("Is Avilable (Y/N)");
                        bool ProductIsAvailable = Console.ReadLine().ToUpper() == "Y" ? true : false;
                        bool IsvalidProductRestaurantName = false;
                        while (!IsvalidProductRestaurantName)
                        {

                            Console.WriteLine("Enter Restaurant Name:");
                            string ProductRestaurantName = Console.ReadLine();





                            IsvalidProductRestaurantName = true;
                            IsvalidAvailable = true;
                            IsValidPrice = true;
                            IsValidName = true;
                            IsProductAdded = true;

                        }
                    }
                }
            }
        } 
    }
}
