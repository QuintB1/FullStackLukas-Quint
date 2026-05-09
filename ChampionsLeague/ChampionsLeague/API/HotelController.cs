using ChampionsLeague.Models;
using ChampionsLeague.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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


        [HttpGet("search")]
        public async Task<IActionResult> SearchHotels()
        {
            var json = await _hotelService.SearchHotelsAsync("brussels");

            var doc = JsonDocument.Parse(json);

            var hotels = doc.RootElement
                .GetProperty("data")
                .EnumerateArray()
                .Select((h, index) => new
                {
                    id = index + 1,
                    name = h.GetProperty("name").GetString(),
                    price = h.GetProperty("nr_hotels").GetInt32() + " hotels available"
                });

            return Ok(hotels);
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
