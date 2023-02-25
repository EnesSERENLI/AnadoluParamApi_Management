using AnadoluParamApi.Data.Mapping.Abstract;
using AnadoluParamApi.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnadoluParamApi.Data.Mapping.Concrete
{
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.UnitPrice)
                .HasPrecision(18, 2)
                .HasConversion<decimal>()
                .IsRequired(true);

            builder.Property(x => x.Quantity).IsRequired(true);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);

            base.Configure(builder);
        }
    }
}
