using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models.Context
{
    public class SQLDBContext : DbContext
    {
        public SQLDBContext(DbContextOptions<SQLDBContext> options) : base(options)
        { 
            
        }

        public DbSet<Employee> Employee { get; set; }

    }
}
