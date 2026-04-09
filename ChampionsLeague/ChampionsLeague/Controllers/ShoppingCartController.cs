using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
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

        public async Task<IActionResult> Index()
        {
            var orders = await _order.GetAllAsync();

            var viewModels = orders
                .Where(x => x.Status == "shoppingcart")
                .SelectMany(o => o.OrderLines)
                .Select(ol => new OrderLineVM
                {
                    ProductId = ol.ProductId,
                    ProductName = ol.Product.Name,
                    UnitPrice = ol.Product.UnitPrice,
                    OrderDate = ol.Order.OrderDate
                })
                .ToList();

            return View(viewModels);
        }
    }
}
