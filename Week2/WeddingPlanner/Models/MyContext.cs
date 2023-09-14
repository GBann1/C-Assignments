#pragma warning disable CS8618
// DbSet & Context is defined
using Microsoft.EntityFrameworkCore;
// Either using or namespace for the models
namespace WeddingPlanner.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) {}
    public DbSet<User> Users { get; set; } 
    public DbSet<Wedding> Weddings { get; set; } 
    public DbSet<UserWedding> UserWeddings { get; set; } 
}