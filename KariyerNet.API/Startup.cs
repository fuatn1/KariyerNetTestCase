using KariyerNet.Core.Repositories;
using KariyerNet.Core.Services;
using KariyerNet.Core.UnitOfWorks;
using KariyerNet.Data;
using KariyerNet.Data.Repositories;
using KariyerNet.Data.UnitOfWorks;
using KariyerNet.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KariyerNet.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using KariyerNet.Dto;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using KariyerNet.API.Extensions;

namespace KariyerNet.API
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
            services.AddScoped<NotFoundFilterForCompany>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyUserService, CompanyUserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<KariyerDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSql"),o=> {
                    o.MigrationsAssembly("KariyerNet.Data");
                });
            }); 
            
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.CustomException();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
