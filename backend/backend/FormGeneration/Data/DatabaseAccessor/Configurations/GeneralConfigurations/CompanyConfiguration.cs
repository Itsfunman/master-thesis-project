using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.FormGeneration.Data.DatabaseAccessor.Configurations.GeneralConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("companyTable");
        builder.HasKey(e => e.CompanyId);
        builder.Property(e => e.CompanyId)
            .HasColumnName("CompanyID")
            .IsRequired();
        
        builder.Property(e => e.CompanyName)
            .HasColumnName("CompanyName")
            .IsRequired();
            
    }
}