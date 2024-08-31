using Backend.Infra.EntityLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.EntityLibrary.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    public DbSet<User?> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
}