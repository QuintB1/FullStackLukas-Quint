using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly IClubService _clubService;
        private readonly IService<Match> _MatchService;
        private readonly IMapper _mapper;
        public MatchController(IClubService clubService, IService<Match> matchService, IMapper mapper)
        {
            _clubService = clubService;
            _MatchService = matchService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<MatchVM>> Detail(int id)
        {
            var match = await _MatchService.FindByIdAsync(id);

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
        public async Task<IActionResult> Index()
        {
            // 1. Get clubs with a home stadium
            var clubs = await _clubService.GetAllWithMatches();

            // 2. Map to CalendarSelectVM list
            var vmList = _mapper.Map<List<ClubSelectVM>>(clubs);

            // 3. Return the view with the mapped list
            return View(vmList);
        }
    }
}
