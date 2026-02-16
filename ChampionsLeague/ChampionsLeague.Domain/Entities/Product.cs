using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Domain.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public DateOnly StartDate { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
