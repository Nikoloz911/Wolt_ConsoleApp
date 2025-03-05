namespace Wolt_ConsoleApp.Functions;
internal class Analytics
{
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }

    private static void WriteColoredLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    public static void AnalyticsVoid()
    {
        Clear();
        WriteColoredLine("1. Sort Users By Name", ConsoleColor.Green);
        WriteColoredLine("2. Sort Users By ID", ConsoleColor.Green);
        WriteColoredLine("3. Sort Users By Account Creation Date", ConsoleColor.Green);
        WriteColoredLine("4. Sort Users By Active Status", ConsoleColor.Green);
        WriteColoredLine("5. Sort Users By Wolt Plus Membership", ConsoleColor.Green);
        WriteColoredLine("6. Sort Users By Number of Linked Credit Cards", ConsoleColor.Green);
        WriteColoredLine("7. Sort Users By Total Credit Card Balance", ConsoleColor.Green);
        WriteColoredLine("8. Sort Users By Number of Payments Made", ConsoleColor.Green);
        WriteColoredLine("9. Sort Users By Total Ordered Products", ConsoleColor.Green);

        WriteColoredLine("10. Sort Credit Cards By Expiry Date", ConsoleColor.Yellow);
        WriteColoredLine("11. Sort Credit Cards By Available Balance", ConsoleColor.Yellow);
        WriteColoredLine("12. Sort Credit Cards By Number of Transactions", ConsoleColor.Yellow);

        WriteColoredLine("13. Sort Payments By Total Amount", ConsoleColor.Green);
        WriteColoredLine("14. Sort Payments By Payment Status", ConsoleColor.Green);

        WriteColoredLine("15. Sort Orders By Number of Users", ConsoleColor.Yellow);
        WriteColoredLine("16. Sort Orders By Number of Restaurants Involved", ConsoleColor.Yellow);
        WriteColoredLine("17. Sort Orders By Status", ConsoleColor.Yellow);

        WriteColoredLine("18. Sort Order Items By Number of Products Included", ConsoleColor.Green);
        WriteColoredLine("19. Sort Order Items By Total Price", ConsoleColor.Green);
        WriteColoredLine("20. Sort Order Items By Total Quantity", ConsoleColor.Green);
        WriteColoredLine("21. Sort Order Items By Order Date", ConsoleColor.Green);

        WriteColoredLine("22. Sort Products By Associated Restaurants", ConsoleColor.Yellow);
        WriteColoredLine("23. Sort Products By Availability Status", ConsoleColor.Yellow);
        WriteColoredLine("24. Sort Products By Stock Quantity", ConsoleColor.Yellow);
        WriteColoredLine("25. Sort Products By Price", ConsoleColor.Yellow);

        WriteColoredLine("26. Sort Restaurants By Account Balance", ConsoleColor.Green);
        WriteColoredLine("27. Sort Restaurants By Rating", ConsoleColor.Green);
        WriteColoredLine("28. Sort Restaurants By Delivery Availability", ConsoleColor.Green);
        WriteColoredLine("29. Sort Restaurants By Number of Orders Received", ConsoleColor.Green);

        string choice = Console.ReadLine();
        Clear();
        switch (choice)
        {
            case "1":
                LinqFunctions.All_LINQ.SortUsersByName();
                break;
            case "2":
                LinqFunctions.All_LINQ.SortUsersById();
                break;
            case "3":
                LinqFunctions.All_LINQ.SortUsersByUserCreatedDate();
                break;
            case "4":
                LinqFunctions.All_LINQ.SortUsersByActiveStatus();
                break;
            case "5":
                LinqFunctions.All_LINQ.SortUsersByWoltPlusSubscription();
                break;
            case "6":
                LinqFunctions.All_LINQ.SortUsersByLinkedCreditCards();
                break;
            case "7":
                LinqFunctions.All_LINQ.SortUsersByCreditCardsBalance();
                break;
            case "8":
                LinqFunctions.All_LINQ.SortUsersByTotalPayments();
                break;
            case "9":
                LinqFunctions.All_LINQ.SortUsersByOrderedProducts();
                break;
            case "10":
                break;
            case "11":
                break;
            case "12":
                break;
            case "13":
                break;
            case "14":
                break;
            case "15":
                break;
            case "16":
                break;
            case "17":
                break;
            case "18":
                break;
            case "19":
                break;
            case "20":
                break;
            case "21":
                break;
            case "22":
                break;
            case "23":
                break;
            case "24":
                break;
            case "25":
                break;
            case "26":
                break;
            case "27":
                break;
            case "28":
                break;
            case "29":
                break;
            default:
                Line();
                WriteColoredLine("Invalid choice!", ConsoleColor.Red);
                Line();
                break;
        }
    }
}
