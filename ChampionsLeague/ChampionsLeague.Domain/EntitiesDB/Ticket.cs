using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class Ticket
{
    public int ProductId { get; set; }

    public int TicketId { get; set; }

    public int MatchId { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();
}
