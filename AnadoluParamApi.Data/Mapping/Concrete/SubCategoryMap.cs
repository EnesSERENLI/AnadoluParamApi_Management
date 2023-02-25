using AnadoluParamApi.Data.Mapping.Abstract;
using AnadoluParamApi.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnadoluParamApi.Data.Mapping.Concrete
{
    public class SubCategoryMap : BaseMap<SubCategory>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.SubCategoryName).IsRequired(true).HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(1000);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.CategoryId);

            base.Configure(builder);
        }
    }
}
