using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = await _order.GetUserShoppingCart(userID);

            // Pass null to the view if no cart exists
            if (cart == null)
                return View(null);

            var vm = _mapper.Map<OrderVM>(cart);
            return View(vm);
        }

    }
}
