using AutoMapper;
using ChampionsLeague.Data;
using ChampionsLeague.Domain.DataDB;
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
        private readonly IService<Match> _matchService;
        private readonly IMapper _mapper;
        private readonly ChampionLeagueDbContext _context;
        public MatchController(IClubService clubService, IMatchService matchService, IMapper mapper, ChampionLeagueDbContext applicationDbContext)
        {
            _clubService = clubService;
            _matchService = matchService;
            _mapper = mapper;
            _context = applicationDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<MatchVM>> Detail(int id)
        {
            var match = await _matchService.FindByIdAsync(id);

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

        [HttpPost]
        public async Task<IActionResult> Index(ClubSelectVM club)
        {
            if (club.ClubId == 0)
            {
                return NotFound();
            }

            var filteredMatches = await _context.Matches
                .Include(m => m.HomeClubNavigation)
                .Include(m => m.AwayClubNavigation)
                .Where(m => m.HomeClub == club.ClubId)
                .ToListAsync();

            var result = filteredMatches.Select(m => new MatchVM
            {
                Id = m.MatchId,
                DateTime = m.DateTime,
                HomeClubId = m.HomeClub,
                AwayClubId = m.AwayClub,
                HomeClubName = m.HomeClubNavigation.Name,
                AwayClubName = m.AwayClubNavigation.Name,
                StadiumId = m.StadiumId
            }).ToList();

            return PartialView("_MatchList", result);
        }
    }
}
