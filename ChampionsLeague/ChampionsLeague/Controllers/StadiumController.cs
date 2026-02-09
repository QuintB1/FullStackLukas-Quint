using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    public class StadiumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
