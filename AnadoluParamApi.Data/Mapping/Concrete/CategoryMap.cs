using AnadoluParamApi.Data.Mapping.Abstract;
using AnadoluParamApi.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnadoluParamApi.Data.Mapping.Concrete
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.CategoryName).IsRequired(true)
                .HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(1000);

            base.Configure(builder);
        }
    }
}
