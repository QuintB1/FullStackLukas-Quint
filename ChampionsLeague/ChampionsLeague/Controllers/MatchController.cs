using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
