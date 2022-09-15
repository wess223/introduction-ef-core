using EntroductionEF.Models;
using Microsoft.EntityFrameworkCore;

namespace EntroductionEF.Repositories.cs
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(p =>
            {
                p.ToTable("Clients");
                p.HasKey(p => p.Id);
                p.Property(p => p.Name).HasColumnType("VARCHAR(80)").IsRequired();
                p.Property(p => p.Telephone).HasColumnType("CHAR(11)").IsRequired();
                p.Property(p => p.Cep).HasColumnType("CHAR(8)").IsRequired();
                p.Property(p => p.State).HasColumnType("CHAR(2)").IsRequired();
                p.Property(P => P.City).HasMaxLength(60).IsRequired();

                p.HasIndex(i => i.Telephone).HasDatabaseName("idx_client_telephone");
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Products");
                p.HasKey(p => p.Id);
                p.Property(p => p.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
                p.Property(p => p.Description).HasColumnType("VARCHAR(60)");
                p.Property(p => p.Value).IsRequired();
                p.Property(p => p.TypeProduct).HasConversion<string>();
            });

            modelBuilder.Entity<Solicitation>(p =>
            {
                p.ToTable("Solicitations");
                p.HasKey(p => p.Id);
                p.Property(p => p.StartDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                p.Property(p => p.Status).HasConversion<string>();
                p.Property(p => p.TypeShipping).HasConversion<int>();
                p.Property(p => p.Observation).HasColumnType("VARCHAR()512");

                p.HasMany(p => p.ItemList)
                .WithOne(p => p.Solicitation)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SolicitationItem>(p =>
            {
                p.ToTable("SolicitationItems");
                p.HasKey(p => p.Id);
                p.Property(p => p.Quantity).HasDefaultValue(1).IsRequired();
                p.Property(p => p.Value).IsRequired();
                p.Property(p => p.Discount).IsRequired();
            });
        }


        public DbSet<Solicitation> Solicitations { get; set; }
    }
}
