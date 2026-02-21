using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public DateOnly StartDate { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
