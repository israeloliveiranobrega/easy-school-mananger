using EasySchoolManager.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolManager.Infra.MapSettings.Base
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id); 
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by");
            builder.Property(e => e.CreateDate).HasColumnName("created_date").HasDefaultValueSql("NOW()");

            builder.Property(e => e.LastUpdatedBy).HasColumnName("updated_by");
            builder.Property(e => e.LastUpdateDate).HasColumnName("updated_date");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            builder.Property(e => e.DeletedDate).HasColumnName("deleted_date");

            builder.Property(e => e.Version)
                .HasColumnName("xmin")
                .HasColumnType("xid")
                .IsRowVersion()
                .ValueGeneratedOnAdd()
                .IsRequired(true);
        }
    }
}
