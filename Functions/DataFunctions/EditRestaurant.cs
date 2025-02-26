using FluentValidation;
using Wolt_ConsoleApp.Data;
using Wolt_ConsoleApp.Models;
using Wolt_ConsoleApp.Validators;
namespace Wolt_ConsoleApp.Functions.DataFunctions;
internal class EditRestaurant
{
    public static DataContext _context = new DataContext();
    private static EditRestaurantValidator _validator = new EditRestaurantValidator();
    public static void Clear() => Console.Clear();
    public static int Line() { Console.WriteLine(new string('-', 60)); return 60; }
    public static int LineLong() { Console.WriteLine(new string('-', 100)); return 100; }
    public static bool EditRestaurantVoid()
    {
        while (true)
        {
            Clear();
            Console.WriteLine("Enter Restaurant Name:");
            string restaurantName = Console.ReadLine();
            if (string.IsNullOrEmpty(restaurantName))
            {
                ShowMessage("Restaurant Name cannot be empty.");
                if (!AskTryAgain()) return false;
                continue;
            }
            var matchingRestaurants = _context.Restaurants
                .Where(r => r.RestaurantName.ToLower() == restaurantName.ToLower())
                .ToList();
            if (matchingRestaurants.Count == 0)
            {
                ShowMessage("No restaurant found with that name.");
                ShowAllRestaurants();
                if (!AskTryAgain()) return false;
                continue;
            }
            Restaurants selectedRestaurant = matchingRestaurants.Count == 1 ? matchingRestaurants.First() : matchingRestaurants.First();
            Clear();
            Line();
            Console.WriteLine($"Editing Restaurant: {selectedRestaurant.RestaurantName}");
            Line();
            Console.WriteLine("1. Edit Restaurant Name");
            Console.WriteLine("2. Edit Restaurant Balance");
            Console.WriteLine("3. Edit Restaurant Rating");
            Console.WriteLine("4. Edit Delivery Availability");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                EditRestaurantName(selectedRestaurant);
            }
            else if (choice == "2")
            {
                EditRestaurantBalance(selectedRestaurant);
            }
            else if (choice == "3")
            {
                EditRestaurantRating(selectedRestaurant);
            }
            else if (choice == "4")
            {
                EditDeliveryAvailability(selectedRestaurant);
            }
            else
            {
                ShowMessage("Invalid choice.");
                if (!AskTryAgain()) return true;
                continue;
            }
            break; 
        }
        return true;
    }

    // Edit Restaurant Name
    private static void EditRestaurantName(Restaurants selectedRestaurant)
    {
        while (true)
        {
            Clear();
            Console.WriteLine("Enter new Restaurant Name:");
            string newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                ShowMessage("Restaurant name cannot be empty.");
                if (!AskTryAgain()) return;
                continue;
            }
            if (selectedRestaurant.RestaurantName == newName)
            {
                ShowMessage("The new restaurant name is the same as the current one. Please enter a different name.");
                if (!AskTryAgain()) return;
                continue;
            }
            selectedRestaurant.RestaurantName = newName;
            var result = _validator.Validate(selectedRestaurant);
            if (!result.IsValid)
            {
                ShowValidationErrors(result);
                if (!AskTryAgain()) return;
                continue;
            }
            _context.SaveChanges();
            Clear();
            Line();
            ShowSuccessMessage($"Restaurant New Name is: {newName}");
            break;
        }
    }
    // Edit Restaurant Balance
    private static void EditRestaurantBalance(Restaurants selectedRestaurant)
    {
        while (true)
        {
            Clear();
            Console.WriteLine("Enter new Restaurant Balance:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal newBalance) || newBalance < 0)
            {
                ShowMessage("Invalid input. Please enter a valid positive number.");
                if (!AskTryAgain()) return;
                continue;
            }
            if (selectedRestaurant.RestaurantBalance == newBalance)
            {
                ShowMessage("The balance is the same as the current one. Please enter a different amount.");
                if (!AskTryAgain()) return;
                continue;
            }
            selectedRestaurant.RestaurantBalance = newBalance;
            var result = _validator.Validate(selectedRestaurant);
            if (!result.IsValid)
            {
                ShowValidationErrors(result);
                if (!AskTryAgain()) return;
                continue;
            }
            _context.SaveChanges();
            Clear();
            Line();
            ShowSuccessMessage($"Restaurant {selectedRestaurant.RestaurantName} New Balance Is: {newBalance}");
            break;
        }
    }
    // Edit Restaurant Rating
    private static void EditRestaurantRating(Restaurants selectedRestaurant)
    {
        while (true)
        {
            Clear();
            Console.WriteLine("Enter new Restaurant Rating:");
            if (!double.TryParse(Console.ReadLine(), out double newRating) || newRating < 0 || newRating > 10)
            {
                ShowMessage("Invalid input. Please enter a valid rating between 0 and 10.");
                if (!AskTryAgain()) return;
                continue;
            }
            if (selectedRestaurant.Rating == newRating)
            {
                ShowMessage("The rating is the same as the current one. Please enter a different rating.");
                if (!AskTryAgain()) return;
                continue;
            }
            selectedRestaurant.Rating = newRating;
            var result = _validator.Validate(selectedRestaurant);
            var ratingErrors = result.Errors.Where(e => e.PropertyName == "Rating").ToList();
            if (ratingErrors.Any())
            {
                foreach (var failure in ratingErrors)
                {
                    ShowMessage(failure.ErrorMessage);
                }
                if (!AskTryAgain()) return;
                continue;
            }
            _context.SaveChanges();
            Clear();
            Line();
            ShowSuccessMessage($"Restaurant {selectedRestaurant.RestaurantName} New Rating Is: {newRating}");
            break;
        }
    }

    // Edit Restaurant Delivery Availability
    private static void EditDeliveryAvailability(Restaurants selectedRestaurant)
    {
        while (true)
        {
            Clear();
            Console.WriteLine("Enter new Delivery Availability (yes/no):");
            string availability = Console.ReadLine().ToLower();
            if ((selectedRestaurant.DeliveryAvailable && availability == "yes") || (!selectedRestaurant.DeliveryAvailable && availability == "no"))
            {
                ShowMessage("The delivery availability is the same as the current one. Please enter a different availability.");
                if (!AskTryAgain()) return;
                continue;
            }
            selectedRestaurant.DeliveryAvailable = availability == "yes";
            var validationResult = _validator.Validate(selectedRestaurant);
            if (!validationResult.IsValid)
            {
                ShowValidationErrors(validationResult);
                if (!AskTryAgain()) return;
                continue;
            }
            _context.SaveChanges();
            Clear();
            Line();
            ShowSuccessMessage($"Restaurant {selectedRestaurant.RestaurantName} New Availability Is: {availability}");
            break;
        }
    }

    private static void ShowValidationErrors(FluentValidation.Results.ValidationResult validationResult)
    {
        Line();
        foreach (var failure in validationResult.Errors)
        {
            Console.WriteLine($"Error: {failure.ErrorMessage}");
        }
        Line();
    }
    private static void ShowSuccessMessage(string message)
    {
        Clear();
        LineLong();
        Console.WriteLine(message);
        LineLong();
    }
    private static void ShowMessage(string message)
    {
        Clear();
        Line();
        Console.WriteLine(message);
        Line();
    }
    public static void ShowAllRestaurants()
    {
        Console.WriteLine("Available Restaurants:");
        LineLong();
        foreach (var restaurant in _context.Restaurants)
        {
            Console.WriteLine($"ID: {restaurant.Id}, Name: {restaurant.RestaurantName}");
        }
        LineLong();
    }

    public static bool AskTryAgain()
    {
        Console.WriteLine("1. Try Again");
        Console.WriteLine("2. Main Menu");
        string choice = Console.ReadLine();
        Clear();
        if(choice == "1") return true;
        else if (choice == "2") return false;
        else return false;
    }
}

