
using IntroductionEF.Data;
using IntroductionEF.Enums;
using IntroductionEF.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroductionEFCore.Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //InsertDados();
            //InsertDadosDivers();
            //ConsultDados();
            //InsertSolicitation();
            ConsultSolicitationAdvanced();
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

        private static void ConsultDados()
        {
            using var db = new DataContext();

            //var sintaxeConsult = (from c in db.Clients where c.Id > 0 select c).ToList();
            var methodoConsult = db.Clients
                .Where(p => p.Id > 0)
                .OrderBy(x => x.Id)
                .ToList();

            foreach (var client in methodoConsult)
            {
                Console.WriteLine($"Consultando cliente: {client.Id}");
                //db.Clients.Find(client.Id);
                db.Clients.FirstOrDefault(x => x.Id == client.Id);
            }

            //quando uma consulta é feita, logo é criada um rastreamento para cada registro.
            //Onde se algum desses registror houver mudança e em seguida chamar os SavaChanges as alterações serão aplicadas.
            //Se quiser evitar o rastreio usa-se o attr AsNoTracking, assim as alterações não serão aplicadas.
            //O methodo Find() busca os dados em memoria, se não trackeadas ele buscara na base de dados.


        }

        private static void InsertSolicitation()
        {
            using var db = new DataContext();

            var client = db.Clients.FirstOrDefault();
            var product = db.Products.FirstOrDefault();

            var solicitation = new Solicitation
            {
                ClientId = client.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Observation = "Pedido teste",
                Status = StatusSolicitation.Analise,
                TypeShipping = TypeShipping.SemFrete,
                ItemList = new List<SolicitationItem>
                {
                    new SolicitationItem
                    {
                        ProductId = product.Id,
                        Discount = 0,
                        Quantity = 1,
                        Value = 10
                    }
                }
            };

            db.Solicitations.Add(solicitation);
            db.SaveChanges();
        }

        private static void ConsultSolicitationAdvanced()
        {
            using var db = new DataContext();
            var list = db.Solicitations
                .Include(x => x.ItemList)
                .ThenInclude(x => x.Product)
                .ToList();
            Console.WriteLine($"COUNT: { list.Count}");
        }
    }
}
