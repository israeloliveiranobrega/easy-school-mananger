using EasySchoolMananger.Infra.MapSettings.Base;
using EasySchoolMananger.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolMananger.Infra.MapSettings
{
    public class TeacherMap : BaseMap<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);

            builder.ToTable("secretaries");
        }
    }
}
