using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class SubscriptionAssignment
{
    public int SubscriptionId { get; set; }

    public string UserId { get; set; } = null!;

    public int? SeatId { get; set; }

    public bool Active { get; set; }

    public int AssignmentId { get; set; }

    public virtual Seat? Seat { get; set; }

    public virtual Subscription Subscription { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
