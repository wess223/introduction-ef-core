using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionEF.Models
{
    public class SolicitationItem
    {
        public int Id { get; set; }
        public int SolicitationId { get; set; }
        public Solicitation Solicitation { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal Discount { get; set; }

    }
}
