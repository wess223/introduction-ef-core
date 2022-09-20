using IntroductionEF.Data.Configurations;
using IntroductionEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace IntroductionEF.Data
{
    public class DataContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Solicitation> Solicitations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=IntroductionEFCore; Integrated Security=True",
                      p => p.EnableRetryOnFailure(
                      maxRetryCount: 2,
                      maxRetryDelay: TimeSpan.FromSeconds(5),
                      errorNumbersToAdd: null)
                      .MigrationsHistoryTable("HistoryEFCoreMigrations", null));
            //default se não configurar o EnabledRetryOnFailure ele irá tentar se conectar 6x ate completar 1 minuto.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplique a configuração para todas as classes concretas que estão implementando IEntityTypeConfiguration nesse assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            MappingPropertyForgotten(modelBuilder);
        }

        private static void MappingPropertyForgotten(ModelBuilder modelBuilder)
        {
            //carrega a lista de entidades da aplicação.
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                //obtenho todas as propriedades em string
                var propertieList = entity.GetProperties().Where(x => x.ClrType == typeof(string));

                foreach (var property in propertieList)
                {
                    //identificado se a regra foi aplicada
                    //verifica se a coluna estar vazia e se tem um length definido
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        //seto um valor default
                        //property.SetMaxLength(100);
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }
    }
}
