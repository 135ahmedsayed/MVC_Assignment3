namespace MVC_Assignment3_DAL.Context;
public class CompanyDBContext(DbContextOptions<CompanyDBContext> options)
    : DbContext(options)
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyDBContext).Assembly);
    }
    // Creating in appsettings.json file 
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}
}
