using EasySchoolMananger.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySchoolMananger.Infra.MapSettings.Base
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseMetaData
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName($"pk_{typeof(T).Name.ToLower()}"); 

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.CreateDate)
                .HasColumnName("created_date")
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("updated_by")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(e => e.UpdateDate)
                .HasColumnName("updated_by")
                .IsRequired(false);

            builder.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false)
                .IsRequired(false);

            builder.Property(e => e.DeletedBy)
                .HasColumnName("deleted_by")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(e => e.DeletedDate)
                .HasColumnName("created_by")
                .IsRequired(false);

            builder.Property(e => e.Version)
                .HasColumnName("xmin")
                .HasColumnType("xid")
                .IsRowVersion()
                .ValueGeneratedOnAdd()
                .IsRequired(true);
        }
    }
}
