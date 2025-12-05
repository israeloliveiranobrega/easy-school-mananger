using EasySchoolMananger.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolMananger.Infra.MapSettings
{
    public class SecretaryMap : IEntityTypeConfiguration<Secretary>
    {
        public void Configure(EntityTypeBuilder<Secretary> builder)
        {
            builder.ToTable("secretaries");
        }
    }
}
