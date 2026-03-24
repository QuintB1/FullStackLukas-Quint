using System;
using System.Collections.Generic;

namespace ChampionsLeague.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
