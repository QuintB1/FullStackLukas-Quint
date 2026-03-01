using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class Subscription
{
    public int ClubId { get; set; }

    public int ProductId { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
