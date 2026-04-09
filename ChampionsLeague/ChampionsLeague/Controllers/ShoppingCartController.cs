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
            var filtered = orders.Where(x => x.Status == "shoppingcart");
            var orderLines = filtered.Select(f => f.OrderLines);

            var viewModels = orderLines.Select(ol => new OrderLineVM
            {
                
            }).ToList();

            return View(viewModels);
        }
    }
}
