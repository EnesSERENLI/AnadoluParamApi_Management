using AnadoluParamApi.Data.Mapping.Abstract;
using AnadoluParamApi.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnadoluParamApi.Data.Mapping.Concrete
{
    public class OrderMap : BaseMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasOne(x => x.Account)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.AccountId);

            base.Configure(builder);
        }
    }
}
