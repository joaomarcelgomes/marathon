using Backend.Infra.EntityLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.EntityLibrary.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Match> Matches { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Team)
            .WithMany(t => t.Users)
            .OnDelete(DeleteBehavior.Restrict); // Ou Ignore
    }
}