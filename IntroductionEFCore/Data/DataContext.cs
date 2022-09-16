using IntroductionEF.Data.Configurations;
using IntroductionEF.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroductionEF.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=IntroductionEFCore; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplique a configuração para todas as classes concretas que estão implementando IEntityTypeConfiguration nesse assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }


        public DbSet<Solicitation> Solicitations { get; set; }
    }
}
