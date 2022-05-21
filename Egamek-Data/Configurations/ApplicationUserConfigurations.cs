using Egamek_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Data.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(o => o.Image).HasDefaultValue("pp.png");
            builder.Property(o => o.Name).IsRequired().HasMaxLength(255);
            builder.Property(o => o.Surname).IsRequired().HasMaxLength(255);
            builder.Property(o => o.GenderId).HasDefaultValue("3");
        }
    }
}
