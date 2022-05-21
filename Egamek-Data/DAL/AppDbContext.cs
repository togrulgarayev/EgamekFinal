using System;
using System.Collections.Generic;
using System.Text;
using Egamek_Core.Entities;
using Egamek_Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Egamek_Data.DAL
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ApplicationUserConfigurations());
            builder.ApplyConfiguration(new CommonCategoryConfigurations());
            builder.ApplyConfiguration(new GameCategoryConfigurations());
            builder.ApplyConfiguration(new OperationsConfigurations());
            builder.ApplyConfiguration(new GameConfigurations());
            builder.ApplyConfiguration(new GenderConfigurations());
            builder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Male"},
                new Gender { Id = 2, Name = "Female"},
                new Gender { Id = 3, Name = "NoSelect"}
            );




            base.OnModelCreating(builder);

        }


        public DbSet<Game> Games { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<CommonCategory> CommonCategories { get; set; }
        public DbSet<Operations> Operations { get; set; }

    }
}
