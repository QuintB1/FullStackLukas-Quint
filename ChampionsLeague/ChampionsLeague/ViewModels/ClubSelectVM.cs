using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChampionsLeague.ViewModels
{
    public class ClubSelectVM
    {
        public int ClubId { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<SelectListItem>? Clubs { get; set; }

        public IEnumerable<MatchVM> Matches { get; set; }
    }
}
