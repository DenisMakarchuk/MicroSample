using Common.Constants.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain;

namespace ProductManagement.Data.Configurations
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.Description).HasMaxLength(ValidationConstants.DESCRIPTION_MAX_LENGTH);
            builder.HasMany(_ => _.Orders).WithOne(_ => _.Account).HasForeignKey(_=>_.AccountId);

            builder.HasQueryFilter(_ => _.DeletedDate == null);
        }
    }
}
