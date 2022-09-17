
using IntroductionEF.Data;
using IntroductionEF.Enums;
using IntroductionEF.Models;

namespace IntroductionEFCore.Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertDados();
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
