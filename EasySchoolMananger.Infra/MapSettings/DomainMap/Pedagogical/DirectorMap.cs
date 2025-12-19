using EasySchoolManager.Infra.MapSettings.Base;
using EasySchoolManager.Model.Domain.People.Staff;
using EasySchoolManager.Model.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.DomainMap.Pedagogical
{
    public class DirectorMap : BaseMap<Director>
    {
        public override void Configure(EntityTypeBuilder<Director> builder)
        {
            base.Configure(builder);
            builder.ToTable("directors");

            //shared rimary key with Customer 
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Director>(t => t.Id)
                .HasConstraintName("fk_director_customer_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.ServiceHours).HasColumnName("service_hours");
            builder.Property(t => t.AdmissionDate).HasColumnName("admission_date");
        }
    }
}
