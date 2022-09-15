using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntroductionEF.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
