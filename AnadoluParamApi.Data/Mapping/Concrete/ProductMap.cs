using AnadoluParamApi.Data.Mapping.Abstract;
using AnadoluParamApi.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnadoluParamApi.Data.Mapping.Concrete
{
    public class ProductMap : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ProductName).IsRequired(true).HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.UnitPrice).IsRequired(true)
                .HasPrecision(18, 2)
                .HasConversion(typeof(decimal));
            builder.Property(x => x.UnitsInStock).IsRequired(true)
                .HasConversion<short>();

            builder.Property(x => x.UnitType).IsRequired(false).HasMaxLength(25);

            builder.HasOne(x => x.SubCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SubCategoryId);

            base.Configure(builder);
        }
    }
}
