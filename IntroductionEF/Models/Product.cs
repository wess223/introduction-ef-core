using IntroductionEF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionEF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public bool Active { get; set; }
    }
}
