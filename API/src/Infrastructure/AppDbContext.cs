using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }
}
