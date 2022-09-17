
using IntroductionEF.Data;
using IntroductionEF.Enums;
using IntroductionEF.Models;

namespace IntroductionEFCore.Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // InsertDados();
            InsertDadosDivers();
        }

        private static void InsertDadosDivers()
        {
            var product = new Product
            {
                Description = "Produto2",
                BarCode = "88888",
                Value = 8m,
                TypeProduct = TypeProduct.Embalagem,
                Active = true,
            };

            var client = new Client
            {
                Name = "Bruno",
                Cep = "60556897",
                City = "Fortaleza",
                State = "CE",
                Telephone = "85956412332"
            };

            var clientList = new[]
            {
                new Client
                {
                    Name = "Souza",
                    Cep = "2222233",
                    City = "Fortaleza",
                    State = "CE",
                    Telephone = "85956412332"
                },
                new Client
                {
                    Name = "Silva",
                    Cep = "9898989",
                    City = "Fortaleza",
                    State = "CE",
                    Telephone = "85956412332"
                }
            };

            using var db = new DataContext();
            //db.AddRange(product, client);
            //db.AddRange(clientList);
            db.Set<Client>().AddRange(clientList);

            var registers = db.SaveChanges();

            Console.WriteLine($"Total Registro(s): {registers}");
        }

        private static void InsertDados()
        {
            Product product = new Product
            {
                Description = "Produto teste",
                BarCode = "32112323121",
                Value = 10m,
                TypeProduct = TypeProduct.MercadoriaParaRevenda,
                Active = true,
            };

            using var db = new DataContext();

            //Possiveis Formas de rastreamento de EFCore.

            // db.Products.Add(product);
            //db.Set<Product>().Add(product);
            //db.Entry(product).State = EntityState.Added;
            db.Add(product);

            var resgisters = db.SaveChanges();
            Console.WriteLine($"Total Registros : {resgisters}.");

        }


    }
}
