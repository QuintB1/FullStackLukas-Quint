using AutoMapper;
using ChampionsLeague.Data;
using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Entities;
using ChampionsLeague.Services;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly IClubService _clubService;
        private readonly IMatchService _matchService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ChampionLeagueDbContext _context;
        public MatchController(IClubService clubService, IMatchService matchService, IMapper mapper, ChampionLeagueDbContext applicationDbContext, IOrderService orderService)
        {
            _clubService = clubService;
            _matchService = matchService;
            _orderService = orderService;
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
            try
            {
                ClubSelectVM clubSelectVM = new ClubSelectVM();

                clubSelectVM.Clubs = new SelectList(
                    await _clubService.GetAllAsync(),
                    "ClubId",
                    "Name"
                );

                return View(clubSelectVM);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(ClubSelectVM club)
        {
            if (club.ClubId == 0)
            {
                return NotFound();
            }

            var filteredMatches = await _matchService.GetAllByClubID(club.ClubId);
            List<MatchVM> MatchVM = _mapper.Map<List<MatchVM>>(filteredMatches);

            return PartialView("_MatchList", MatchVM);
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
        public async Task<IActionResult> Details(MatchVM vm)
        {
            return View(vm);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PurchaseTicket(int matchId)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                await _orderService.AddTicketToCart(matchId, userID);
                return View("success");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
