using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChampionsLeague.ViewModels
{
    public class ClubSelectVM
    {
        public int ClubId { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<SelectListItem>? Matches { get; set; }
    }
}
