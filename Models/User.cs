namespace Wolt_ConsoleApp.Models;
internal class User
{
    public int Id { get; set; }
    //public int PaymentId { get; set; }
    public string UserName { get; set; }
    public string UserLastName { get; set; }
    public string UserPassword { get; set; }
    public DateTime UserCreated { get; set; }
    public bool IsActive { get; set; }
    public bool HasWoltPlus { get; set; }
    public UserDetails UserDetails { get; set; } // Navigation property
    public List<Order> Orders { get; set; }  // Navigation property
    //public List<CreditCard> CreditCards { get; set; } // Navigation property
    //public List<Payment> Payments { get; set; }  // Navigation property

}
