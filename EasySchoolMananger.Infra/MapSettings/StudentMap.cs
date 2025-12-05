using EasySchoolMananger.Infra.MapSettings.Base;
using EasySchoolMananger.Model.Base;
using EasySchoolMananger.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolMananger.Infra.MapSettings;

public class StudentMap : BaseMap<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);

        builder.ToTable("student");

        builder.Property(s => s.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.RegistrationDate)
            .HasColumnName("name")
            .HasDefaultValueSql("CURRENT_DATE")
            .IsRequired();

        builder.Property(s => s.DateOfBirth)
            .HasColumnName("date_of_birth")
            .IsRequired();

        builder.Property(s => s.Condition)
            .HasColumnName("condition")
            .HasDefaultValue(Condition.Normal)
            .IsRequired();

        builder.Property(s => s.Occurrences)
            .HasColumnName("occurrences")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(s => s.Highlights)
            .HasColumnName("highlights")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(s => s.IsPCD)
            .HasColumnName("is_pcd")
            .HasColumnName("name")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(s => s.DisabilityType)
            .HasColumnName("disability_type")
            .HasDefaultValue(DisabilityType.Nenhuma)
            .IsRequired();

        builder.Property(s => s.AttentionLevel)
            .HasColumnName("attention_level")
            .HasDefaultValue(AttentionLevel.Nenhum)
            .IsRequired();
    }
}
