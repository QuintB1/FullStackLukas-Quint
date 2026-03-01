using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class OrderLine
{
    public int LineId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public bool? Active { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
