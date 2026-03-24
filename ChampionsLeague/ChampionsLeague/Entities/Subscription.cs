using System;
using System.Collections.Generic;

namespace ChampionsLeague.Entities;

public partial class Subscription
{
    public int ClubId { get; set; }

    public int ProductId { get; set; }

    public DateOnly EndDate { get; set; }

    public DateOnly? StartDate { get; set; }

    public int SubscriptionId { get; set; }

    public int SeatId { get; set; }

    public bool Active { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;
}
