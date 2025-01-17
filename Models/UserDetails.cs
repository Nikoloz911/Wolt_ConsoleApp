namespace Wolt_ConsoleApp.Models;
internal class UserDetails
{
    public int Id { get; set; }
    public int UserId { get; set; }  // Foreign key
    public string UserEmail { get; set; }
    public string UserAddress { get; set; }
    public string UserPhoneNumber { get; set; }
    public User User { get; set; }    // Navigation property
}
