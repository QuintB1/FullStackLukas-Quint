using ChampionsLeague.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace ChampionsLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Culture()
        {
            ViewBag.Today = DateTime.Now;
            ViewBag.Price = 1234.56m;

            ViewBag.CurrentCulture = CultureInfo.CurrentCulture.Name;
            ViewBag.CurrentUICulture = CultureInfo.CurrentUICulture.Name;

            return View();
        }

        [HttpPost]
        public IActionResult SetAppLanguage(string lang, string returnUrl)
        {
            // er wordt een cookie aangemaakt met de naam .AspNetCore.Culture (zie browser cookie)
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue
                (new RequestCulture(lang)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                }
            );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
