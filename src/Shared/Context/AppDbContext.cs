using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;
using LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;
/* using LigaBetPlay.src.Modules.Transferencias.Domain.Entities; */

namespace LigaBetPlay.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Torneo> Torneos => Set<Torneo>();
    public DbSet<Jugador> Jugadors => Set<Jugador>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<CuerpoTecnico> CuerposTec => Set<CuerpoTecnico>();
    public DbSet<CuerpoMedico> CuerposMedicos => Set<CuerpoMedico>();
    /* public DbSet<Transferencia> Transferencias => Set<Transferencia>(); */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}