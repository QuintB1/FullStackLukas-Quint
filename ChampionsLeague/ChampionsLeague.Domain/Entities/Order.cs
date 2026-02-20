using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string UserId { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual AspNetUser User { get; set; } = null!;
}
