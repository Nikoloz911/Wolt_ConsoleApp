namespace Wolt_ConsoleApp.Models;
internal class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; } // Foreign key to Order
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }

    public Order Order { get; set; } // Navigation property to Order
}


