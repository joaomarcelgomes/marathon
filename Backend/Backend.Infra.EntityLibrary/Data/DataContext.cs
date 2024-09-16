using Backend.Infra.EntityLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.EntityLibrary.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Competition> Competitions { get; set; }
}