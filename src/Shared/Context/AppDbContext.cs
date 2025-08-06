using LigaBetPlay.src.Modules.Torneos.Domain.Entities;
using LigaBetPlay2025.src.Modules.Teams.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LigaBetPlay.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Torneo> Torneos => Set<Torneo>();
    public DbSet<Team> Teams => Set<Team>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}