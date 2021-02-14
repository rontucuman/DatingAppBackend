using System.Reflection;
using DatingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Persistence
{
  public class DatingAppContext : DbContext
  {
    public DatingAppContext()
    {
    }

    public DatingAppContext(DbContextOptions<DatingAppContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
