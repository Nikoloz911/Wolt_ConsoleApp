namespace Wolt_ConsoleApp.Models;
internal class CreditCard
{
    public int Id { get; set; }
    public int UserId { get; set; } // Foreign key
    public string CreditCardNumber { get; set; }
    public string CreditCardHolderName { get; set; }
    public DateTime CreditCardExpiryDate { get; set; }
    public string CreditCardCVV { get; set; }
    public decimal CreditCardBalance { get; set; }
    public List<Payment> Payments { get; set; } // Navigation Property
    public User Users { get; set; } // Navigation Property

}
