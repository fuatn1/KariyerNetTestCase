using KariyerNet.Data;
using KariyerNet.Data.Repositories;
using KariyerNet.Data.UnitOfWorks;
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
using KariyerNet.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using KariyerNet.Dto;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using KariyerNet.API.Extensions;
using KariyerNet.Busines.Abstract;
using KariyerNet.Data.Repository.Abstract;
using KariyerNet.Data.UnitOfWorks.Abstract;
using KariyerNet.Busines.Implementation;
using Microsoft.OpenApi.Models;
using KariyerNet.Business.Implementation;

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
            services.AddScoped<NotFoundFilterForCompanyUser>();
            services.AddScoped<NotFoundFilterForJob>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyManager, CompanyManager>();
            services.AddScoped<ICompanyUserManager, CompanyUserManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<KariyerDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSql"),o=> {
                    o.MigrationsAssembly("KariyerNet.Data");
                });
            });
            services.AddScoped<IJobManager, JobManager>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KariyerNet.API", Version = "v1" });
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
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
