﻿using System;
using FagElGamous.Areas.Identity.Data;
using FagElGamous.Data;
using FagElGamous.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FagElGamous.Areas.Identity.IdentityHostingStartup))]
namespace FagElGamous.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<UserLoginContext>(options =>
            //        options.UseSqlServer(
            //            //context.Configuration.GetConnectionString("UserLoginContextConnection")));
            //            Helpers.GetRDSConnectionString()));
            //    services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            //        .AddDefaultUI()
            //        .AddEntityFrameworkStores<UserLoginContext>()
            //        .AddDefaultTokenProviders();
            //});
        }
    }
}