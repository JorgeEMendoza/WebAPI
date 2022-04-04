using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.Models.Context;
using WebAPI.Repositories;
using WebAPI.Repositories.Implementations;
using WebAPI.Web.Services.Contracts;
using WebAPI.Web.Services.Implementations;
using WebAPI.Web.Controllers;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using WebAPI.Web.DataMapping.Contracts;
using WebAPI.Web.DataMapping.Implementations;

namespace WebAPI.Web
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
                    options.UseSqlServer("Server=192.168.2.220; Database=employeesdb; User Id=employeesdb_user; Password=Pa$$word_!@#$", b => b.MigrationsAssembly(typeof(SQLDBContext).Assembly.FullName))).
                AddScoped<IEmployeeService, EmployeeServiceImp>().
                AddScoped<IEmployeeRepo, EmployeeRepoImp>().
                AddSingleton<IEmployeeMapper, EmployeeMapper>();

            //services.AddDatabaseDeveloperPageExceptionFilter();

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(RoutingHelpers.APIVersion,
                                    new OpenApiInfo 
                                    { 
                                        Title = "Employees",
                                        Version = RoutingHelpers.APIVersion 
                                    });
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
