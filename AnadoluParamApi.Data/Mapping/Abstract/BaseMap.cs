using AnadoluParamApi.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnadoluParamApi.Data.Mapping.Abstract
{
    public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel //Database column types and relationships
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Status).IsRequired(true);

            builder.Property(x => x.CreatedIP).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.CreatedDate).IsRequired(false);
            builder.Property(x => x.CreatedComputerName).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.CreatorUserName).IsRequired(false).HasMaxLength(255);

            builder.Property(x => x.UpdatedIP).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.UpdaterUserName).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.UpdatedComputerName).IsRequired(false).HasMaxLength(255);

            builder.Property(x => x.DeletedIP).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.DeletedDate).IsRequired(false);
            builder.Property(x => x.DeleterUserName).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.DeletedComputerName).IsRequired(false).HasMaxLength(255);
        }
    }
}
