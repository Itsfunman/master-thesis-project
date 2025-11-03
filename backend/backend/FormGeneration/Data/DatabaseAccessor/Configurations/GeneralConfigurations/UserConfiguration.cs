using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace backend.FormGeneration.DatabaseAccessor.Configurators;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("userTable");
        builder.HasKey(e => e.UserID);
        builder.Property(e => e.UserID)
            .HasColumnName("UserID")
            .IsRequired();
        
        builder.Property(e => e.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(e => e.DisplayName)
            .HasColumnName("display_name")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("NOW()");

        // Foreign Keys
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Business)
            .WithMany()
            .HasForeignKey(e => e.BusinessID)
            .OnDelete(DeleteBehavior.SetNull);
    }
}