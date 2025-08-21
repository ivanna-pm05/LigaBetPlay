using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LigaBetPlay.src.Shared.Configurations
{
    public class CuerpoTecConfiguration : IEntityTypeConfiguration<CuerpoTecnico>
    {
        public void Configure(EntityTypeBuilder<CuerpoTecnico> builder)
        {
            builder.ToTable("cuerpo_tecnico");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(c => c.Role)
                    .IsRequired()
                    .HasMaxLength(100);
            
            builder.HasOne(ct => ct.Teams)
                .WithMany(e => e.CuerposTecnicos) 
                .HasForeignKey(cm => cm.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}