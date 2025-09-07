using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVC_Assignment3_DAL.Context.Configurations;
internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.Id)
            .UseIdentityColumn(10,10);

        builder.Property(d => d.Name)
            .HasColumnType("VarChar")
            .HasMaxLength(20)
            .IsRequired(true);

        builder.Property(d => d.Description)
            .HasColumnType("VarChar")
            .HasMaxLength(50)
            .IsRequired(true);

        builder.Property(d => d.Code)
            .HasColumnType("VarChar")
            .HasMaxLength(11)
            .IsRequired(true);
        
        builder.Property(d => d.CreateOn)
            .HasDefaultValueSql("GETDATE()");

        
    }
}
