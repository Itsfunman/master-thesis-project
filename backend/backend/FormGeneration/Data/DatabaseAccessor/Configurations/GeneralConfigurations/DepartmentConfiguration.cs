using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.FormGeneration.DatabaseAccessor.Controllers.GeneralControllers;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departmentTable");
        builder.HasKey(e => e.DepartmentID);
        builder.Property(e => e.DepartmentID)
            .HasColumnName("DepartmentID")
            .IsRequired();
        
        builder.Property(e => e.DepartmentName)
            .HasColumnName("DepartmentName")
            .IsRequired();
    }
}