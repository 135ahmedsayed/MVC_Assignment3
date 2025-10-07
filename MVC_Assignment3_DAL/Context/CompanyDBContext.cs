using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVC_Assignment3_DAL.Context;
public class CompanyDBContext(DbContextOptions<CompanyDBContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>(b =>
        {
            b.Property(u => u.FirstName)
                .HasMaxLength(100)
                .HasColumnType("VarChar");
            b.Property(u => u.LastName)
                .HasMaxLength(100)
                .HasColumnType("VarChar");

        });
        //modelBuilder.Ignore<IdentityUserClaim<string>>();   //Ignore Identity Tables
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyDBContext).Assembly);
    }
    // Creating in appsettings.json file 
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}
}
