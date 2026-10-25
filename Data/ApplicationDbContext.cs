using GBC_Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace GBC_Travel.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Flight> Flights => Set<Flight>();
    public DbSet<Hotel> Hotels => Set<Hotel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data: at least 5 flights and 5 hotels (see SeedData.cs).
        modelBuilder.Entity<Flight>().HasData(SeedData.Flights());
        modelBuilder.Entity<Hotel>().HasData(SeedData.Hotels());
    }
}
