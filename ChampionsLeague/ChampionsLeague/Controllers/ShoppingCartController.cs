using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IOrderService _order;
        private readonly IMapper _mapper;
        private String userId;
        private OrderVM cart;
        public ShoppingCartController(IOrderService order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartData = await _order.GetUserShoppingCart(userId);

            // Pass null to the view if no cart exists
            if (cartData == null)
            {
                return View(null);
            }

            cart = _mapper.Map<OrderVM>(cartData);
            return View(cart);
        }
        public async Task<IActionResult> CheckOut(OrderVM order)
        {
            
            return View("success");

        }
        public async Task<IActionResult> RemoveFromCart(int lineId)
        {
            await _order.RemoveFromCart(lineId, userId);

            return RedirectToAction("Index", "ShoppingCart");
        }
        [HttpGet]
        public async Task<IActionResult> GetSectionsForProduct(int productId)
        {
            var sections = await _order.GetSectionsForProduct(productId);
            if (sections == null && sections.Count < 1)
            {
                throw new Exception("no sections found");
            }
            var vm = _mapper.Map<List<StadiumSectionVM>>(sections);

            return Json(vm);
        }


    }
}
