using EasySchoolManager.Infra.MapSettings.Base;
using EasySchoolManager.Model.Base;
using EasySchoolManager.Model.Domain.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.DomainMap.Apprentices
{
    public class SchoolClassMap : BaseMap<SchoolClass>
    {
        public override void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            base.Configure(builder);
            builder.ToTable("school_classes");

            builder.Property(x => x.ClassGrade).HasColumnName("class_grade");
            builder.Property(x => x.ClassLetter).HasColumnName("class_letter");
        }
    }
}
