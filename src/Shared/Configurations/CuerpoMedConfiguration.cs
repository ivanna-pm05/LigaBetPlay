using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LigaBetPlay.src.Shared.Configurations
{
    public class CuerpoMedConfiguration
    {
        public void Configure(EntityTypeBuilder<CuerpoMedico> builder)
        {
            builder.ToTable("CuerposMedicos");

            builder.HasKey(cm => cm.Id);

            builder.Property(cm => cm.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(cm => cm.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(cm => cm.Edad)
            .IsRequired();

            builder.Property(cm => cm.Especialidad)
                .HasMaxLength(100);

            builder.HasOne(cm => cm.Team)
                .WithMany(e => e.cuerpoMedicos) 
                .HasForeignKey(cm => cm.EquipoId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}