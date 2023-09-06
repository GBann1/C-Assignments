#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
namespace LoginAndRegistration.Models;
public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) {}
    public DbSet<User> Users {get;set;}
}