using Erp.Business.Catalog.CustomerBusiness;
using Erp.Model.EntityFramework;
using Erp.Repository.Catalog.CustomerRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erp.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificorigin = "_myAllowSpecificorigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;        
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<Solution_30ShineContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("Solution_30shineContext"),
              //sqlServerOptions => sqlServerOptions.CommandTimeout(30),
              sqlServerOptionsAction: sqlOptions =>
              {
                  sqlOptions.EnableRetryOnFailure(
                  maxRetryCount: 1000,
                  maxRetryDelay: TimeSpan.FromSeconds(30),
                  errorNumbersToAdd: null)
                  .CommandTimeout(30);
              }));

            services.AddCors(option =>
            {
                option.AddPolicy("_myAllowSpecificorigins",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyMethod()
                    );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Erp.Api", Version = "v1" });
            });

            services.AddTransient<ICustomerRepo, CustomerRepo>();
            services.AddTransient<ICustomerBusiness, CustomerBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Erp.Api v1"));
            }

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });
            app.UseCors(MyAllowSpecificorigin);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
