using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Domain.Entities
{
    public partial class Stadium
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SubscriptionSeats { get; set; }
        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
