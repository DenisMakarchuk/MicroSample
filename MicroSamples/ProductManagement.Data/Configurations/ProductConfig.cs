using Common.Constants.ProductManagementConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain;

namespace ProductManagement.Data.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.Name).HasMaxLength(ValidationConstants.NameMaxLength);
            builder.HasMany(_ => _.Orders);

            builder.HasQueryFilter(_ => _.DeletedDate == null);
        }
    }
}
