using ChampionsLeague.Domain.EntitiesDB;
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

            return View();
        }

        [HttpGet]
        public async Task<ActionResult<MatchVM>> Detail(int id)
        {
            var match = await _match.FindByIdAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            var vm = new MatchVM
            {
                Id = match.MatchId,
                DateTime = match.DateTime,
                HomeClubName = match.HomeClubNavigation.Name,
                AwayClubName = match.AwayClubNavigation.Name,
                HomeClubId = match.HomeClubNavigation.ClubId,
                AwayClubId = match.AwayClubNavigation.ClubId,
                StadiumId = match.Stadium.StadiumId
            };

            return View(vm);
        }

    }
}
