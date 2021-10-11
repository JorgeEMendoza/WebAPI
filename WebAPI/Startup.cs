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

            services.AddSwaggerGen();

            services.
                AddDbContext<SQLDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(SQLDBContext).Assembly.FullName))).
                AddScoped(typeof(IRepository<>), typeof(RepositoryImp<>)).

                AddScoped<IEmployee, EmployeeImp>().
                AddScoped<IEmployeeRepo, EmployeeRepoImp>().

                AddScoped<IEmployeeSalary, EmployeeSalaryImp>().
                AddScoped<IEmployeeSalaryRepo, EmployeeSalaryRepoImp>().
                
                AddScoped<IMongoUser, MongoUserImp>().
                AddScoped<IMongoUserRepository, MongoUserRepoImp>();
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json","My API v1");
                    c.RoutePrefix = string.Empty;
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
