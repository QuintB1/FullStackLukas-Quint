using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

public class HotelApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HotelApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> SearchHotelsAsync(string city)
    {
        var apiKey = _configuration["RapidApi:ApiKey"];

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            // ⚠️ Example endpoint (depends on API you choose)
            RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={city}")
        };

        request.Headers.Add("x-rapidapi-key", apiKey);
        request.Headers.Add("x-rapidapi-host", "booking-com15.p.rapidapi.com");

        var response = await _httpClient.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API ERROR: {content}");
        }

        return content;
    }
}
