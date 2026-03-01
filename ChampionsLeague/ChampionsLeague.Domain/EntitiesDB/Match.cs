using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class Match
{
    public int MatchId { get; set; }

    public DateOnly MatchDate { get; set; }

    public int HomeClub { get; set; }

    public int AwayClub { get; set; }

    public int StadiumId { get; set; }

    public virtual Club AwayClubNavigation { get; set; } = null!;

    public virtual Club HomeClubNavigation { get; set; } = null!;

    public virtual Stadium Stadium { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
