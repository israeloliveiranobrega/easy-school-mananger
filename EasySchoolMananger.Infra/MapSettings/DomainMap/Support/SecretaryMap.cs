using EasySchoolManager.Infra.MapSettings.Base;
using EasySchoolManager.Model.Domain.Pedagogical;
using EasySchoolManager.Model.Domain.People.Staff;
using EasySchoolManager.Model.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.DomainMap.Support
{
    public class SecretaryMap : BaseMap<Secretary>
    {
        public override void Configure(EntityTypeBuilder<Secretary> builder)
        {
            base.Configure(builder);
            builder.ToTable("secretaries");

            //shared rimary key with Customer 
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Secretary>(t => t.Id)
                .HasConstraintName("fk_secretary_customer_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.AdmissionDate).HasColumnName("admission_date");
        }
    }
}
