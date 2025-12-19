using EasySchoolManager.Infra.MapSettings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.DomainMap.User;

public class CustomerMap : BaseMap<Model.Domain.People.Base.User>
{
    public override void Configure(EntityTypeBuilder<Model.Domain.People.Base.User> builder)
    {
        base.Configure(builder);
        builder.ToTable("customer");

        builder.Property(c => c.FirstName).HasColumnName("first_name").HasMaxLength(30);
        builder.Property(c => c.LastName).HasColumnName("last_name").HasMaxLength(70);
        builder.Property(s => s.DateOfBirth).HasColumnName("date_of_birth");

        builder.Property(c => c.Email).HasColumnName("email").HasMaxLength(100);
        builder.Property(c => c.Phone).HasColumnName("phone").HasMaxLength(15);
        builder.Property(c => c.Password).HasColumnName("password");

        builder.Property(s => s.RegistrationDate).HasColumnName("registration_date").HasDefaultValueSql("CURRENT_DATE");
    }
}
