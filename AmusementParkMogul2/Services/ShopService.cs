using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Services
{
    public class ShopService
    {
        private readonly HttpClient _httpClient;

        public ShopService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Shop>> GetShopDataAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5253/api/shopapi");
            response.EnsureSuccessStatusCode();

            var shopData = await response.Content.ReadFromJsonAsync<List<Shop>>();
            return shopData;
        }
    } 
}
