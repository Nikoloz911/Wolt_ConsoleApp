namespace Wolt_ConsoleApp.Models;
internal class Order
{
    public int Id { get; set; }
    public int UserId { get; set; } // Foreign key
    public int RestaurantId { get; set; } // Foreign key
    public string OrderStatus { get; set; }
    public Payment Payment { get; set; } // Navigation property
    public User User { get; set; } // Navigation property
    public Restaurants Restaurant { get; set; } // Navigation property
    public List<OrderItem> OrderItems { get; set; }// Navigation property
}


