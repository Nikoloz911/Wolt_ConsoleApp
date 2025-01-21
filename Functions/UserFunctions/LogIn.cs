namespace Wolt_ConsoleApp.Functions.UserFunctions;
internal class LogIn
{
    public static void Clear()
    {
        Console.Clear();
    }
    public static int Line()
    {
        int length = 55;
        string dashLine = new string('-', length);
        Console.WriteLine(dashLine);
        return length;
    }
    public static void UserLogIn()
    {
        bool LogedIn = false;
        while (!LogedIn)
        {
            bool IsValidUserName = false;
            bool IsValidPassword = false;
            while (!IsValidUserName)
            {
                Clear();
                Console.WriteLine("Enter User Name:");
                string UserName = Console.ReadLine();
                while (!IsValidPassword)
                {
                    Clear();
                    Console.WriteLine("Enter User Password:");
                    string Password = Console.ReadLine();
                    //


                    Clear();
                    IsValidPassword = true;
                    IsValidUserName = true;
                    LogedIn = true;
                    //Menu.ShowUserMenu();
                }
            }
        }
    }

}
