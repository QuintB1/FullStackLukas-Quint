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
        private readonly IMatchService _matchService;
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
            var vm = _mapper.Map<MatchVM>(match);

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

            var filteredMatches = _matchService.GetAllByClubID(club.ClubId);
            var MatchVMs = _mapper.Map<List<ClubSelectVM>>(filteredMatches);

            return PartialView("_MatchList", MatchVMs);
        }
        [HttpGet]
        public async Task<IActionResult> GetMatches(int ClubId)
        {
            var matches = await _matchService.GetAllByClubID(ClubId);
            if (matches == null)
            {
                return NotFound();
            }
            var vmlist = _mapper.Map<List<MatchVM>>(matches);
            return Json(vmlist);

        }
    }
}
