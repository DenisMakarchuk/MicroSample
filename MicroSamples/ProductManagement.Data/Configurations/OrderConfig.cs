using Common.Constants.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain;

namespace ProductManagement.Data.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.Description).HasMaxLength(ValidationConstants.DESCRIPTION_MAX_LENGTH);
            builder.HasMany(_ => _.Products);

            builder.HasQueryFilter(_ => _.DeletedDate == null);
        }
    }
}
