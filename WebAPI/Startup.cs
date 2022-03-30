using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Models.Context;
using WebAPI.Repositories.Contracts;
using WebAPI.Repositories.Implementations;
using WebAPI.Services.Contracts;
using WebAPI.Services.Implementations;
using WebAPI.Controllers;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using WebAPI.DataMapping.Contracts;
using WebAPI.DataMapping.Implementations;

namespace WebAPI
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
            services.AddControllers();

            services.
                AddDbContext<SQLDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(SQLDBContext).Assembly.FullName))).
                AddScoped<IEmployeeService, EmployeeServiceImp>().
                AddScoped(typeof(IRepository<>), typeof(RepositoryImp<>)).
                AddScoped<IEmployeeRepo, EmployeeRepoImp>().
                AddSingleton<IEmployeeMapper, EmployeeMapper>();

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(RoutingHelpers.APIVersion, new OpenApiInfo { Title = "Courses", Version = RoutingHelpers.APIVersion });
            });

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/{RoutingHelpers.APIVersion}/swagger.json","Employees API");
                });

            }

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
