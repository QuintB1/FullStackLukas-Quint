using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    public class CancellationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
