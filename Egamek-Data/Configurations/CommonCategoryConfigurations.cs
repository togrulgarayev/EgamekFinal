using Egamek_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Data.Configurations
{
    public class CommonCategoryConfigurations : IEntityTypeConfiguration<CommonCategory>
    {
        public void Configure(EntityTypeBuilder<CommonCategory> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.CreateTime).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        }
    }
}
