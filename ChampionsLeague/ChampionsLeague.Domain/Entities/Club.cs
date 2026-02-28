using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.Entities;

public partial class Club
{
    public int ClubId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public int? HomeStadiumId { get; set; }

    public virtual Stadium? HomeStadium { get; set; }

    public virtual ICollection<Match> MatchAwayClubNavigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchHomeClubNavigations { get; set; } = new List<Match>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
