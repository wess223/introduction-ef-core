using IntroductionEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroductionEF.Data.Configurations
{
    public class SolicitationConfiguration : IEntityTypeConfiguration<Solicitation>
    {
        public void Configure(EntityTypeBuilder<Solicitation> builder)
        {
            builder.ToTable("Solicitations");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StartDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.Status).HasConversion<string>();
            builder.Property(p => p.TypeShipping).HasConversion<int>();
            builder.Property(p => p.Observation).HasColumnType("VARCHAR(512)");

            builder.HasMany(p => p.ItemList)
            .WithOne(p => p.Solicitation)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
