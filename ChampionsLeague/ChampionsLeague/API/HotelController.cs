using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        // STEP 1: Dummy hotel list
        [HttpGet("search")]
        public IActionResult SearchHotels()
        {
            return Ok(new[]
{
    new { id = 1, name = "Hotel Brussels Center", price = "€120" },
    new { id = 2, name = "Grand Palace Hotel", price = "€180" },
    new { id = 3, name = "Airport Comfort Inn", price = "€90" }
});

        }

        // STEP 2: Dummy room offers
        [HttpGet("offers/{hotelId}")]
        public IActionResult GetOffers(int hotelId)
        {
            var offers = new Dictionary<int, string>
    {
        { 1, "Double Room – €120/night" },
        { 2, "Suite – €180/night" },
        { 3, "Standard Room – €90/night" }
    };

            if (!offers.ContainsKey(hotelId))
                return Ok(new { offer = "No offers available" });

            return Ok(new { offer = offers[hotelId] });
        }

    }
}
