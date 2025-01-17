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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Wolt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
