using System;
using System.Collections.Generic;

namespace ChampionsLeague.Entities;

public partial class Seat
{
    public int SeatId { get; set; }

    public int SectionId { get; set; }

    public int SeatNumber { get; set; }

    public virtual StadiumSection Section { get; set; } = null!;

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
