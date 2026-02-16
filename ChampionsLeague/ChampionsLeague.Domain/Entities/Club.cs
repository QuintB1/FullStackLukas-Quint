using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Domain.Entities
{
    public partial class Club
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
