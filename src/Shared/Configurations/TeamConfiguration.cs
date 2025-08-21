using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LigaBetPlay.src.Shared.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("teams");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(t => t.Type)
                     .HasMaxLength(50);

            builder.Property(t => t.Country)
                    .HasMaxLength(50);

            builder.HasMany(t => t.Jugadors)
                    .WithOne(j => j.Team)
                    .HasForeignKey(j => j.TeamId)
                    .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(t => t.CuerposMedicos)
                    .WithOne(cm => cm.Team)
                     .HasForeignKey(cm => cm.TeamId)
                     .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.CuerposMedicos)
                    .WithOne(ct => ct.Team)
                    .HasForeignKey(ct => ct.TeamId)
                    .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(t => t.Torneos)
                .WithMany(tor => tor.Teams)
                .UsingEntity<Dictionary<string, object>>(
                "team_torneo", 
                r => r.HasOne<Torneo>().WithMany().HasForeignKey("TorneoId").OnDelete(DeleteBehavior.Cascade),
                l => l.HasOne<Team>().WithMany().HasForeignKey("TeamId").OnDelete(DeleteBehavior.Cascade),
                je =>
                {
                    je.HasKey("TorneoId", "TeamId");
                    je.ToTable("team_torneo");
                }
                );
        }
    }
}