using EasySchoolManager.Infra.MapSettings.Base;
using EasySchoolManager.Model.Base.Enums;
using EasySchoolManager.Model.Domain.People.Staff;
using EasySchoolManager.Model.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.DomainMap.Pedagogical
{
    public class TeacherMap : BaseMap<Teacher>
    {
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);
            builder.ToTable("teachers");

            //shared rimary key with Customer 
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Teacher>(t => t.Id)
                .HasConstraintName("fk_teacher_customer_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.Schedule).HasColumnName("service_hours");
            builder.Property(t => t.TeacherType).HasColumnName("teacher_type");
            builder.Property(t => t.AdmissionDate).HasColumnName("admission_date");
        }
    }
}
