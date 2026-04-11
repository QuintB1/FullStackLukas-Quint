using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class Subscription
{
    public int ClubId { get; set; }

    public int ProductId { get; set; }

    public int SubscriptionId { get; set; }

    public int? SeasonId { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Season? Season { get; set; }

    public virtual ICollection<SubscriptionAssignment> SubscriptionAssignments { get; set; } = new List<SubscriptionAssignment>();
}
