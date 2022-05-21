using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Egamek_Business.Implementations;
using Egamek_Business.Interfaces;
using Egamek_Core;
using Egamek_Core.Entities;
using Egamek_Data.DAL;
using Egamek_Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Egamek
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddControllersWithViews()
            //    .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<ProductCreateViewModelValidator>());
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Default"]);
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(Options =>
            {
                Options.Password.RequiredLength = 8;
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = false;
                Options.Password.RequireDigit = true;


                Options.User.AllowedUserNameCharacters = "abcçdeəfgğhiıjklmnopqrsştuüvyzxqwWABCÇDEƏFGĞHİIJKLMNOPQRSŞTUÜVYZXQ0123456789-._ ";
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Error/Problem");
            });

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "1830517130672656";
                options.AppSecret = "15d1a61c771e9155ac19225f73dba97f";
            });

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "710061989061-d7qaisjallrs7fd472r2mlj32n0rkkvs.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameCategoryService, GameCategoryService>();
            services.AddScoped<ICommonCategoryService, CommonCategoryService>();
            services.AddScoped<IOperationsService, OperationsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
