using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Data.EF.Models;

namespace WebAPI.Data.EF.MigrationScripts
{
    public class EmployeeMigrationContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public virtual DbSet<EmployeeDataModel> Employees { get; set; }
        public virtual DbSet<PhoneNumberDataModel> PhoneNumber { get; set; }
        public virtual DbSet<AddressDataModel> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //"Server=192.168.2.220; Database=employeesdb; User Id=employeesdb_user; Password=Pa$$word_!@#$"
            optionsBuilder.UseSqlServer("Server=192.168.2.220; Database=employeesdb; User Id=employeesdb_user; Password=Pa$$word_!@#$");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDataModel>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PhoneNumberDataModel>(entity =>
            {
                entity.ToTable("phone_numbers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PhoneNumbers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeePhoneNumberIdFK");
            });

            modelBuilder.Entity<AddressDataModel>(entity =>
            {
                entity.ToTable("addresses");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeeAddressIdFK");
            });

            //DbInitializer.Initialize(this);
        }

    }
}
