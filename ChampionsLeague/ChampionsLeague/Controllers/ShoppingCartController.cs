using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IService<Order> _order;
        public ShoppingCartController(IService<Order> order)
        {
            _order = order;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var orders = await _order.GetAllAsync();

            var viewModels = orders
                .Where(o => o.Status == "cart")
                .Select(o => new OrderVM
                {
                    OrderDate = o.OrderDate,
                    OrderLines = o.OrderLines.Select(ol => new OrderLineVM
                    {
                        ProductId = ol.ProductId,
                        ProductName = ol.Product.Name,
                        UnitPrice = ol.Product.DynamicUnitPrice
                    }).ToList()
                })
                .ToList();

            return View(viewModels);
        }
    }
}
