using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LigaBetPlay.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Torneo> Torneos => Set<Torneo>();
    public DbSet<Jugador> Jugadors => Set<Jugador>();
    public DbSet<CuerpoTecnico> CuerpoTec => Set<CuerpoTecnico>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}