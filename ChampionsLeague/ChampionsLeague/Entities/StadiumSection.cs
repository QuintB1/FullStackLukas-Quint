using System;
using System.Collections.Generic;

namespace ChampionsLeague.Entities;

public partial class StadiumSection
{
    public int SectionId { get; set; }

    public int StadiumId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual Stadium Stadium { get; set; } = null!;
}
