using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LigaBetPlay.src.Shared.Configurations;

public class TorneoConfiguration : IEntityTypeConfiguration<Torneo>
{
    public void Configure(EntityTypeBuilder<Torneo> builder)
    {
        builder.ToTable("torneo");

        builder.HasKey(t => t.ID);

        builder.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.Type)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.Country)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.FechaInicio)
               .IsRequired()
               .HasMaxLength(100);
        
        builder.Property(t => t.FechaFin)
               .IsRequired()
               .HasMaxLength(100);
    }
}