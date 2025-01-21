void Line() => Console.WriteLine(new string('-', 60));

bool running = true;
while (running)
{
    Console.WriteLine("1. User Management");
    Console.WriteLine("2. Product Management");
    Console.WriteLine("3. Restaurants Management");
    Console.WriteLine("4. Analytics");
    Console.WriteLine("5. File Management");
    Console.WriteLine("6. System Logs");
    Console.WriteLine("7. Exit App");
    string choice = Console.ReadLine();
    if (choice == "1")
    {

    }
    else if (choice == "2")
    {

    }
    else if (choice == "3")
    {

    }
    else if (choice == "4")
    {

    }
    else if (choice == "5")
    {

    }
    else if (choice == "6")
    {

    }
    else if (choice == "7")
    {

    }
    else
    {
        Line();
        Console.WriteLine("Invalid choice");
        Line();
    }
}