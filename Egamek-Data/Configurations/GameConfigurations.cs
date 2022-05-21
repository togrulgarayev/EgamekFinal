using Egamek_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Data.Configurations
{
    public class GameConfigurations : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(g => g.Name).IsRequired().HasMaxLength(255);
            builder.Property(g => g.Description).IsRequired().HasColumnType("TEXT");
            builder.Property(g => g.Iframe).IsRequired().HasColumnType("TEXT");
            builder.Property(g => g.IsDeleted).HasDefaultValue(false);
            builder.Property(g => g.Ram).IsRequired().HasMaxLength(255);
            builder.Property(g => g.VideoCard).IsRequired().HasMaxLength(255);
            builder.Property(g => g.Space).IsRequired().HasMaxLength(255);
            builder.Property(g => g.Processor).IsRequired().HasMaxLength(255);
            builder.Property(g => g.OperatingSystem).IsRequired().HasMaxLength(255);
            builder.Property(g => g.Image).IsRequired().HasMaxLength(255);
            builder.Property(g => g.CreateTime).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
