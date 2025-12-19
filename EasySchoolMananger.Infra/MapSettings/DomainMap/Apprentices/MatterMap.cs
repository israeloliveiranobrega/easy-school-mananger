using EasySchoolManager.Infra.MapSettings.Base;
using EasySchoolManager.Model.Domain.Academic;
using EasySchoolManager.Model.Domain.People.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.DomainMap.Apprentices
{
    public class MatterMap : BaseMap<Subject>
    {
        public override void Configure(EntityTypeBuilder<Subject> builder)
        {
            base.Configure(builder);
            builder.ToTable("materials");

            builder.Property(t => t.TeacherId).HasColumnName("teacher_id");

            builder.HasOne<Teacher>()
                .WithMany()
                .HasForeignKey(s => s.TeacherId)
                .HasConstraintName("fk_matter_teacher_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.MatterList).HasColumnName("matter_list");
            builder.Property(s => s.Other).HasColumnName("other").HasMaxLength(30);
        }
    }
}
