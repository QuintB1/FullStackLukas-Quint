using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class OrderLine
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal StaticUnitPrice { get; set; }

    public int Quantity { get; set; }

    public int LineId { get; set; }

    public int? StadiumSectionId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual StadiumSection? StadiumSection { get; set; }
}
