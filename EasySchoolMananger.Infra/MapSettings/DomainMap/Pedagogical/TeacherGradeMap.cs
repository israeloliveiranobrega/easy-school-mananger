using EasySchoolManager.Infra.MapSettings.Base;
using EasySchoolManager.Model.Base.Enums;
using EasySchoolManager.Model.Domain.Academic;
using EasySchoolManager.Model.Domain.People.Staff;
using EasySchoolManager.Model.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.DomainMap.Pedagogical
{
    public class TeacherGradeMap : BaseMap<TeacherGrade>
    {
        public override void Configure(EntityTypeBuilder<TeacherGrade> builder)
        {
            base.Configure(builder);
            builder.ToTable("teacher_grades");

            builder.Property(t => t.TeacherId)
                .HasColumnName("teacher_id");

            builder.Property(t => t.ClassId)
                .HasColumnName("class_id");

            builder.HasOne<Teacher>()
                .WithMany()
                .HasForeignKey(t => t.TeacherId)
                .HasConstraintName("fk_teacher_grade_teacher_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<SchoolClass>()
                .WithMany()
                .HasForeignKey(t => t.ClassId)
                .HasConstraintName("fk_teacher_grade_class_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.WeekDay).HasColumnName("week_day");
            builder.Property(t => t.ClassTime).HasColumnName("class_time");
        }
    }
}
