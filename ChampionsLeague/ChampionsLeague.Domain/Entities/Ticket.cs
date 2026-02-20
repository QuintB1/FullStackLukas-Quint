using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.Entities;

public partial class Ticket
{
    public int MatchId { get; set; }

    public int SectionId { get; set; }

    public int SeatNr { get; set; }

    public int ProductId { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual StadiumSection Section { get; set; } = null!;
}
