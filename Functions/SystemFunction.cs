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
        Console.WriteLine("4. Show");
        string choice = Console.ReadLine();
        Clear();
        if(choice == "1")
        {

        }
        else if(choice == "2")
        {

        }
        else if (choice == "3")
        {

        }
        else if (choice == "4")
        {

        }
        else
        {

        }
    }
}
