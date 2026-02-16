using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Domain.Entities
{
    public class Order
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public DateOnly OrderDate { get; set; }
    }
}
