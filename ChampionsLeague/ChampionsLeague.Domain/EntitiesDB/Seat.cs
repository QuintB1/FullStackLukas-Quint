using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class Seat
{
    public int SeatId { get; set; }

    public int SectionId { get; set; }

    public int SeatNumber { get; set; }

    public virtual ICollection<SubscriptionAssignment> SubscriptionAssignments { get; set; } = new List<SubscriptionAssignment>();

    public virtual ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();
    public virtual StadiumSection Section { get; set; } = null!;

}
