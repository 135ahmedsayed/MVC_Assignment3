using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Assignment3_DAL.Entities.Enums;

namespace MVC_Assignment3_DAL.Context.Configurations;
public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(d => d.Id)
            .UseIdentityColumn(1, 1);
        builder.Property(e => e.Name)
            .HasColumnType("VarChar")
            .IsRequired(true)
            .HasMaxLength(30);
        builder.Property(e => e.Email)
            .HasColumnType("VarChar")
            .IsRequired(false)
            .HasMaxLength(30);
        builder.Property(e => e.PhoneNumber)
            .HasColumnType("Char")
            .IsRequired(false)
            .HasMaxLength(11);
        builder.Property(e => e.Salary)
            .HasColumnType("decimal(10,2)")
            .IsRequired(true);
        builder.Property(g => g.gender)
            .HasConversion(x => x.ToString(), y => Enum.Parse<Gender>(y));
        builder.Property(g => g.employeeType)
            .HasConversion(x => x.ToString(), y => Enum.Parse<EmployeeType>(y));
        //HasConversion(Convert TO , Convert From)

        //Relation
        builder.HasOne(d => d.department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId);
    }
}
