﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Data.Context;
using Cozy.Data.Implementation.EFCore;
using Cozy.Data.Implementation.Mock;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cozy.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Repository Layer
            //GetDependencyResolvedForRepositoryLayer(services);
            GetDependencyResolvedForEFCoreLayer(services);

            // Service Layer
            GetDependencyResolvedForServiceLayer(services);

            services.AddDbContext<CozyDbContext>();
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<CozyDbContext>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseAuthentication(); // makes use of Identity

            app.UseMvcWithDefaultRoute();
        }

        private void GetDependencyResolvedForRepositoryLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeRepository, MockHomeRepository>();
            services.AddScoped<ILeaseRepository, MockLeaseRepository>();
            //services.AddScoped<IMaintenanceRepository, MockMaintenanceRepository>();
        }

        private void GetDependencyResolvedForEFCoreLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeRepository, EFCoreHomeRepository>();
            services.AddScoped<ILeaseRepository, EFCoreLeaseRepository>();
            //services.AddScoped<IMaintenanceRepository, EFCoreMaintenanceRepository>();
        }

        private void GetDependencyResolvedForServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ILeaseService, LeaseService>();
        }
    }


}
