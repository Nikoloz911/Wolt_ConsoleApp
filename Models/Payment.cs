namespace Wolt_ConsoleApp.Models;
internal class Payment
{
    public int Id { get; set; }
    public int OrderId { get; set; } // Foreign key
    public int UserId { get; set; } // Foreign key 
    public int CreditCardId { get; set; } // Foreign key 
    public decimal TotalAmount { get; set; }
    public string PaymentStatus { get; set; }
    public Order Order { get; set; } // Navigation Property
    public User User { get; set; } // Navigation Property 
    public CreditCard CreditCard { get; set; } // Navigation Property
}

