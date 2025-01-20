namespace Wolt_ConsoleApp.Models;
internal class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; } // Foreign key 
    public int ProductId { get; set; } // Foreign key
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}


