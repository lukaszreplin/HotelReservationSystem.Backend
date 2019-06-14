using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.MongoDB;
using HotelReservationSystem.Contracts;
using HotelReservationSystem.Infrastructure;
using HotelReservationSystem.Models;
using HotelReservationSystem.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;

namespace HotelReservationSystem
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddIdentity<ApplicationUser, MongoIdentityRole>()
                .AddDefaultTokenProviders();
            services
                .Configure<MongoDBOption>(Configuration.GetSection("MongoDBOption"))
                .AddMongoDatabase()
                .AddMongoDbContext<ApplicationUser, MongoIdentityRole>()
                .AddMongoStore<ApplicationUser, MongoIdentityRole>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Hotel Reservation System API", Version = "v1" });
            });

            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MongoConnectionString")))
            {
                Environment.SetEnvironmentVariable("MongoConnectionString", "mongodb://mo1356_hrs:Hotel123@mongo11.mydevil.net:27017/mo1356_hrs");
            }

            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DbName")))
            {
                Environment.SetEnvironmentVariable("DbName", "mo1356_hrs");
            }

            services.AddSingleton<IMongoClient>(new MongoClient(Environment.GetEnvironmentVariable("MongoConnectionString")));
            services.AddRepository();

            services.AddService();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Reservation System API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
