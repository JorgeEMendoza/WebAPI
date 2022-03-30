using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Employee;

namespace WebAPI.Models.Context
{
    public class SQLDBContext : DbContext
    {
        public SQLDBContext(DbContextOptions<SQLDBContext> options) : base(options)
        { 
            
        }

        public DbSet<Employee_Main> Employee_Main { get; set; }

        public DbSet<Employee.Employee> Employee { get; set; }

    }
}
