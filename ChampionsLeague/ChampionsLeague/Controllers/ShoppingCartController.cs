using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
