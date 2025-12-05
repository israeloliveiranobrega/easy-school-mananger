using EasySchoolMananger.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolMananger.Infra.MapSettings;

public class CoordinatorMap : IEntityTypeConfiguration<Coordinator>
{
    public void Configure(EntityTypeBuilder<Coordinator> builder)
    {
        builder.ToTable("coordinators");
    }
}
