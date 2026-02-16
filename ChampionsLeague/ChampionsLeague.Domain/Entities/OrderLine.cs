using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Domain.Entities
{
    public partial class OrderLine
    {
        public int LineId  { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product ProductNrNavigation { get; set; } = null!;
        public virtual Order OrderNrNavigation { get; set; } = null!;
    }
}
