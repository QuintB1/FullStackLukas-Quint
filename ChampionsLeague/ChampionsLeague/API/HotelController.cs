using ChampionsLeague.Models;
using ChampionsLeague.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private readonly HotelApiService _hotelService;

        public HotelController(HotelApiService hotelService)
        {
            _hotelService = hotelService;
        }


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


        [HttpGet("search-real")]
        public async Task<IActionResult> SearchRealHotels(string city = "BRU")
        {
            var result = await _hotelService.SearchHotelsAsync(city);
            return Ok(result);
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



        [HttpPost("book")]
        public IActionResult BookHotel([FromBody] HotelBooking booking)
        {
            // Save to DB (or mock)
            return Ok(new { message = "Hotel booked successfully!" });
        }


    }
}
