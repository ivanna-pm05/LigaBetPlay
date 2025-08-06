using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay2025.src.Modules.Teams.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LigaBetPlay2025.src.Shared.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("teams");

            builder.HasKey(tm => tm.Id);

            builder.Property(tm => tm.Name)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
}