using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LigaBetPlay.src.Shared.Configurations;

public class JugadorConfiguration : IEntityTypeConfiguration<Jugador>
{
    public void Configure(EntityTypeBuilder<Jugador> builder)
    {
        builder.ToTable("jugador");

        builder.HasKey(j => j.ID);

        builder.Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(j => j.LastName)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(j => j.Dorsal)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(j => j.Position)
                .IsRequired()
                .HasMaxLength(100);
        
        builder.Property(j => j.Country)
                .IsRequired()
                .HasMaxLength(100);
    }
}
