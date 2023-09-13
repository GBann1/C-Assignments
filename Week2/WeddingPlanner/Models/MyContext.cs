#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) {}
    public DbSet<User> Users { get; set; } 
    public DbSet<Wedding> Weddings { get; set; } 
    public DbSet<UserWedding> UserWeddings { get; set; } 
}