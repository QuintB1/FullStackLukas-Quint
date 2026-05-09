using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.ManifestUtilities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IClubService _clubService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public StadiumController(
            IClubService clubService,
            IOrderService orderService,
            IMapper mapper)
        {
            _clubService = clubService;
            _orderService = orderService;
            _mapper = mapper;
        }

        // MAIN PAGE
        public async Task<IActionResult> Index()
        {
            var clubs = await _clubService.GetAllWithHomeStadium();
            var vmList = _mapper.Map<List<HomeclubStadiumSelectVM>>(clubs);
            return View(vmList);
        }

        // AJAX: GET STADIUM DETAILS
        [HttpGet]
        public async Task<IActionResult> GetStadium(int stadiumId)
        {
            var stadium = await _orderService.GetStadiumById(stadiumId);

            if (stadium == null)
                return NotFound();

            var vm = _mapper.Map<StadiumVM>(stadium);
            return Json(vm);
        }

        // ADD SUBSCRIPTION TO CART
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddSubscriptionToCart(int clubId)
        {
            try
            {
                var userId = GetUserId();

                await _orderService.AddSubscriptionToCart(clubId, userId);

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
