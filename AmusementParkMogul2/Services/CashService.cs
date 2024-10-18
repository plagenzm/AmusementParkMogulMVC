using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Services
{
    public class CashService
    {
        private readonly HttpClient _httpClient;

        public CashService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cash>> GetCashDataAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5253/api/cashapi");
            response.EnsureSuccessStatusCode();

            var cashData = await response.Content.ReadFromJsonAsync<List<Cash>>();
            return cashData;
        }
    } 
}
