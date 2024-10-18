using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Services
{
    public class GentlerideService
    {
        private readonly HttpClient _httpClient;

        public GentlerideService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Gentleride>> GetGentlerideDataAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5253/api/gentlerideapi");
            response.EnsureSuccessStatusCode();

            var gentlerideData = await response.Content.ReadFromJsonAsync<List<Gentleride>>();
            return gentlerideData;
        }
    } 
}
