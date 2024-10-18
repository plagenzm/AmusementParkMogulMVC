using AmusementParkMogul2.Models;
using System.Web.Mvc;

namespace AmusementParkMogul2.Services
{
    public class ParkService
    {
        private readonly HttpClient _httpClient;

        public ParkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Park>> GetParkDataAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5253/api/parkapi");
            response.EnsureSuccessStatusCode();

            var parkData = await response.Content.ReadFromJsonAsync<List<Park>>();
            return parkData;
        }
    } 
}
