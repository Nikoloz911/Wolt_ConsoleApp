namespace Wolt_ConsoleApp.Models;
internal class Restaurants
{
    public int Id { get; set; }
    public string RestaurantName { get; set; }
    public double Rating { get; set; }
    public bool DeliveryAvailable { get; set; }
    public List<Product> Products { get; set; }// Navigation property
    public List<Order> Orders { get; set; } // Navigation property

}
