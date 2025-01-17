namespace Wolt_ConsoleApp.Models;
internal class Order
{
    public int Id { get; set; }
    public int UserId { get; set; } // Foreign key to User
    public int RestaurantId { get; set; } // Foreign key to Restaurants
    public string OrderStatus { get; set; }

    public User User { get; set; } // Navigation property to User
    public Restaurants Restaurant { get; set; } // Navigation property to Restaurants
    public List<OrderItem> OrderItems { get; set; } // Navigation property to OrderItems
}


