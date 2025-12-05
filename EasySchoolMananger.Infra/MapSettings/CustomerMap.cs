using EasySchoolMananger.Infra.MapSettings.Base;
using EasySchoolMananger.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolMananger.Infra.MapSettings;

public class CustomerMap : BaseMap<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder.ToTable("customer");

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Phone)
            .HasColumnName("phone")
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(c => c.Password)
            .HasColumnName("password")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(s => s.RegistrationDate)
            .HasColumnName("registration_date")
            .HasDefaultValueSql("CURRENT_DATE")
            .IsRequired();

        builder.Property(s => s.DateOfBirth)
            .HasColumnName("date_of_birth")
            .IsRequired(false);
    }
}
