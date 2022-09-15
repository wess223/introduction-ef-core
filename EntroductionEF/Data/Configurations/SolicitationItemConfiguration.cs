using EntroductionEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntroductionEF.Data.Configurations
{
    public class SolicitationItemConfiguration : IEntityTypeConfiguration<SolicitationItem>
    {
        public void Configure(EntityTypeBuilder<SolicitationItem> builder)
        {
            builder.ToTable("SolicitationItems");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantity).HasDefaultValue(1).IsRequired();
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.Discount).IsRequired();
        }
    }
}
