using ConsumerMicroservice.Models;
using ConsumerMicroservice.RepositoryLayer;
using ConsumerMicroservice.RepositoryLayer.IRepositoryLayer;
using ConsumerMicroservice.ServiceLayer;
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

namespace ConsumerMicroservice
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
            // Using CROS for cross connection to access end points from Angular
            services.AddCors();
            services.AddCors(c =>
            {
                c.AddPolicy("CorsPolicy", options => options.WithOrigins("http://localhost:4200").AllowAnyMethod()
                 .AllowAnyHeader().AllowCredentials());
            });
            services.AddScoped<IConsumerRepository, ConsumerRepository>();
            services.AddScoped<IConsumerBusinessRepository, ConsumerBusinessRepository>();
            services.AddScoped<IBusinessPropertyRepository, BusinessPropertyRepository>();
            services.AddScoped<IConsumerService, ConsumerService>();
            services.AddControllers();
            services.AddDbContext<InsureityPortalDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("TestConnectionString")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ConsumerMicroservice", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsumerMicroservice v1"));
            }

            app.UseCors("CorsPolicy");
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
