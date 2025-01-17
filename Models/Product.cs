namespace Wolt_ConsoleApp.Models;
internal class Product
{
    public int Id { get; set; }
    public int RestaurantsId { get; set; } // Foreign key to Restaurants
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public bool IsAvailable { get; set; }

    public Restaurants Restaurants { get; set; } // Navigation property to Restaurants
}

