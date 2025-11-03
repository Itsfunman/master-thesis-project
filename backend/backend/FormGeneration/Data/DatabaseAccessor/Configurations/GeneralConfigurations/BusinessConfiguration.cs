using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.FormGeneration.Data.DatabaseAccessor.Configurations.GeneralConfigurations;

public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.ToTable("businesssTable");
        builder.HasKey(e => e.BusinessID);
        builder.Property(e => e.BusinessID)
            .HasColumnName("BusinessID")
            .IsRequired();

        builder.Property(e => e.BusinessName)
            .HasColumnName("BusinessName")
            .IsRequired();
    }
}