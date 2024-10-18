using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Services
{
    public class RollercoasterService
    {
        private readonly HttpClient _httpClient;

        public RollercoasterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Rollercoaster>> GetRollercoasterDataAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5253/api/rollercoasterapi");
            response.EnsureSuccessStatusCode();

            var rollercoasterData = await response.Content.ReadFromJsonAsync<List<Rollercoaster>>();
            return rollercoasterData;
        }
    } 
}
