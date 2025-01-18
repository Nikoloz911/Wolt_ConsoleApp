using Microsoft.EntityFrameworkCore;
using Wolt_ConsoleApp.Models;
namespace Wolt_ConsoleApp.Data;
internal class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserDetails> UsersDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Restaurants> Restaurants { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Wolt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Order) 
            .WithOne(o => o.Payment) 
            .HasForeignKey<Payment>(p => p.OrderId) 
            .OnDelete(DeleteBehavior.Cascade); 
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.User) 
            .WithMany(u => u.Payments) 
            .HasForeignKey(p => p.UserId) 
            .OnDelete(DeleteBehavior.Restrict); 
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.CreditCard) 
            .WithMany()
            .HasForeignKey(p => p.CreditCardId) 
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
