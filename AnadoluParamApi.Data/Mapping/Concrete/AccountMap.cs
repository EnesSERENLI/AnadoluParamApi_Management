using AnadoluParamApi.Data.Mapping.Abstract;
using AnadoluParamApi.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnadoluParamApi.Data.Mapping.Concrete
{
    public class AccountMap : BaseMap<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired(false).HasMaxLength(100);

            builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(127);
            builder.Property(x => x.Role).IsRequired(true).HasMaxLength(25);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(25);
            builder.Property(x => x.Gender).IsRequired(false)
                .HasConversion<char>()
                .HasMaxLength(2);
            builder.Property(x => x.LastActivity).IsRequired(false);


            base.Configure(builder);
        }
    }
}
