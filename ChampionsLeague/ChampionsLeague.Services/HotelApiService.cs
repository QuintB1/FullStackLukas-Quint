using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services
{
    public class HotelApiService
    {

        private readonly HttpClient _httpClient;

        public HotelApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SearchHotelsAsync(string city)
        {
            var url = $"https://test.api.amadeus.com/v1/reference-data/locations/hotels?cityCode={city}";

            // ⚠ You need an access token from Amadeus
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "YOUR_ACCESS_TOKEN");

            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();

        }
    }
}
