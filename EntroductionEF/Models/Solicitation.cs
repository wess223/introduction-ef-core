using EntroductionEF.Enums;

namespace EntroductionEF.Models
{
    public class Solicitation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TypeShipping TypeShipping { get; set; }
        public StatusServiceOrder Status { get; set; }
        public string Observation { get; set; }
        public ICollection<SolicitationItem> SolicitationItemList { get; set; }
    }
}
