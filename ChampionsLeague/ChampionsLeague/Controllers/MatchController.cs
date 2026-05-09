using AutoMapper;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ChampionsLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly IClubService _clubService;
        private readonly IMatchService _matchService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public MatchController(
            IClubService clubService,
            IMatchService matchService,
            IMapper mapper,
            IOrderService orderService)
        {
            _clubService = clubService;
            _matchService = matchService;
            _orderService = orderService;
            _mapper = mapper;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        // -------------------------
        // MAIN PAGE
        // -------------------------
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vm = new ClubSelectVM
            {
                Clubs = new SelectList(
                    await _clubService.GetAllAsync(),
                    "ClubId",
                    "Name"
                )
            };

            return View(vm);
        }

        // -------------------------
        // AJAX: LOAD MATCHES
        // -------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ClubSelectVM club)
        {
            if (club.ClubId == 0)
            {
                return PartialView("_MatchList", new List<MatchVM>());
            }

            var matches = await _matchService.GetAllByClubID(club.ClubId);
            var vmList = _mapper.Map<List<MatchVM>>(matches);

            return PartialView("_MatchList", vmList);
        }

        // -------------------------
        // ADD TICKET TO CART
        // -------------------------
        [HttpGet]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddTicketToCart(int matchId)
        {
            try
            {
                var userId = GetUserId();
                Console.WriteLine("userID: " + userId);

                await _orderService.AddTicketToCart(matchId, userId);

                return RedirectToAction("Index", "ShoppingCart");
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return BadRequest(ex.Message);
                }
                return BadRequest(ex.InnerException.Message);
            }
        }

    }
}
