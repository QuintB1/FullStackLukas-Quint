using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class Stadium
{
    public int StadiumId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public int SubscriptionSeats { get; set; }

    public virtual ICollection<Club> Clubs { get; set; } = new List<Club>();

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual ICollection<StadiumSection> StadiumSections { get; set; } = new List<StadiumSection>();
}
