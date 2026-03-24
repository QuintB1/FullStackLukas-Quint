using System;
using System.Collections.Generic;

namespace ChampionsLeague.Entities;

public partial class Ticket
{
    public int MatchId { get; set; }

    public int ProductId { get; set; }

    public int SeatId { get; set; }

    public int TicketId { get; set; }

    public bool Active { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;
}
