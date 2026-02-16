using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Domain.Entities
{
    public partial class Match
    {
        public DateOnly Date { get; set; }
        public int HomeClub {  get; set; }
        public int AwayClub { get; set; }
        public int StadiumId { get; set; }
        public int MatchId { get; set; }
        public virtual Stadium StadiumNrNavigation { get; set; } = null!;
        public virtual Club ClubNrNavigation { get; set; } = null!;
    }
}
