using FagElGamous.Areas.Identity.Data;
using FagElGamous.Data;
using FagElGamous.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous
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
            services.AddDbContext<FagElGamousContext>(options =>
                options.UseSqlServer(
                    //Configuration.GetConnectionString("FagElGamousConnection")));
                    Helpers.GetRDSConnectionString()));


            services.AddDbContext<UserLoginContext>(options =>
                    options.UseSqlServer(
                        //context.Configuration.GetConnectionString("UserLoginContextConnection")));
                        Helpers.GetRDSConnectionString()));
            services.AddIdentity<FagElGamousUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddEntityFrameworkStores<UserLoginContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //authenticating with google
            services.AddAuthentication();
                //.AddGoogle(options =>
                //{
                //    IConfigurationSection googleAuthNSection =
                //        Configuration.GetSection("Authentication:Google");

                //    options.ClientId = googleAuthNSection["ClientId"];
                //    options.ClientSecret = googleAuthNSection["ClientSecret"];
                //});

            services.AddAuthorization(options =>
            {

                //access for researcher
                options.AddPolicy("researcherPolicy",
                    builder => builder.RequireRole("SuperUser", "Researcher"));
                //access for SuperUser
                options.AddPolicy("adminPolicy",
                    builder => builder.RequireRole("SuperUser"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                //            endpoints.MapControllerRoute("teamnamepagenum",
                //"TeamName/{teamId}/{teamName}/{pagenum}",
                //new { Controller = "Home", action = "Index" }
                //);
                //endpoints.MapControllerRoute("filter",
                //"Filter/{LocationId}/{pagenum}",
                //    new { Controller = "Home", action = "Filter" }
                //   );
                //endpoints.MapControllerRoute("filter",
                //"Filter/{LocationId}/{Age}/{pagenum}",
                //new { Controller = "Home", action = "Filter" }
                //);
                endpoints.MapControllerRoute("filter",
                    "Filter/{LocationId}-{Age}-{HeadDirection}/{pagenum}",
                    new { Controller = "Home", action = "Filter" }
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
