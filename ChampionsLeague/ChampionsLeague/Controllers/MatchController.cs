using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly IService<Match> _match;
        public MatchController(IService<Match> match)
        {
            _match = match;
        }
        public async Task<IActionResult> Index()
        {

            var matches = await _match.GetAllAsync();

            var vm = matches.Select(m => new MatchVM
            {
                Id = m.MatchId,
                Date = m.MatchDate,
                HomeClubName = m.HomeClubNavigation.Name,
                AwayClubName = m.AwayClubNavigation.Name,
                HomeClubId = m.HomeClubNavigation.ClubId,
                AwayClubId = m.AwayClubNavigation.ClubId,
                StadiumId = m.Stadium.StadiumId
            });

            return View(vm);
        }

    }
}
