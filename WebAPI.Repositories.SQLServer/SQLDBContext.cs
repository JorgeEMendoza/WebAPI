using Microsoft.EntityFrameworkCore;
using WebAPI.Data.EF.Models;

namespace WebAPI.Models.Context
{
    public class SQLDBContext : DbContext
    {
        public SQLDBContext(DbContextOptions<SQLDBContext> options) : base(options)
        { 
            
        }

        public DbSet<EmployeeDataModel> Employee { get; set; }

    }
}
