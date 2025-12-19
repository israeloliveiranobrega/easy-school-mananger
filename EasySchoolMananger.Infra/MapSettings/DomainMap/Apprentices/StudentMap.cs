using EasySchoolManager.Infra.MapSettings.Base;
using EasySchoolManager.Model.Base.ValueObjects;
using EasySchoolManager.Model.Domain.Academic;
using EasySchoolManager.Model.Domain.People.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.DomainMap.Apprentices;

public class StudentMap : BaseMap<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);
        builder.ToTable("students");

        builder.Property(t => t.ClassID).HasColumnName("class_id");

        builder.HasOne<SchoolClass>()
            .WithMany()
            .HasForeignKey(s => s.ClassID)
            .HasConstraintName("fk_student_class_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(s => s.FirstName).HasColumnName("first_name").HasMaxLength(30);
        builder.Property(s => s.LastName).HasColumnName("last_name").HasMaxLength(70);
        builder.Property(s => s.DateOfBirth).HasColumnName("date_of_birth");

        builder.Property(s => s.Schedule).HasColumnName("service_hours");
        builder.Property(s => s.Condition).HasColumnName("condition").HasDefaultValue(Condition.Normal);
        builder.Property(s => s.Occurrences).HasColumnName("occurrences").HasDefaultValue(0);
        builder.Property(s => s.Highlights).HasColumnName("highlights").HasDefaultValue(0);

        builder.Property(s => s.IsPCD).HasColumnName("is_pcd");
        builder.Property(s => s.DisabilityType).HasColumnName("disability_type").HasDefaultValue(DisabilityType.Nenhuma);
        builder.Property(s => s.AttentionLevel).HasColumnName("attention_level").HasDefaultValue(AttentionLevel.Nenhum);

        builder.Property(s => s.RegistrationDate).HasColumnName("registration_date").HasDefaultValueSql("CURRENT_DATE");
    }
}
