using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
