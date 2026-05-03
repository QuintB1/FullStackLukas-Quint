using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IOrderService _order;
        private readonly IMapper _mapper;

        public ShoppingCartController(IOrderService order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartData = await _order.GetUserShoppingCart(userId);

            if (cartData == null)
                return View(null);

            var vm = _mapper.Map<OrderVM>(cartData);
            return View(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CheckOut(string cartJson)
        {
            if (string.IsNullOrWhiteSpace(cartJson))
                return BadRequest("Cart JSON was not received.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var vm = JsonConvert.DeserializeObject<OrderVM>(cartJson);

            var order = _mapper.Map<Order>(vm);

            await _order.UpdateCart(order, userId);

            return View("Success");
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int lineId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _order.RemoveFromCart(lineId, userId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetSectionsForProduct(int productId)
        {
            var sections = await _order.GetSectionsForProduct(productId);

            if (sections == null || sections.Count < 1)
                return NotFound("No sections found");

            var vm = _mapper.Map<List<StadiumSectionVM>>(sections);

            return Json(vm);
        }
    }
}
