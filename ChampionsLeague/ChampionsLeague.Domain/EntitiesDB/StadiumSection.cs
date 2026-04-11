using System;
using System.Collections.Generic;

namespace ChampionsLeague.Domain.EntitiesDB;

public partial class StadiumSection
{
    public int SectionId { get; set; }

    public int StadiumId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual Stadium Stadium { get; set; } = null!;
}
