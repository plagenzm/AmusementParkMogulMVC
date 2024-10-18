using AmusementParkMogul2.Models;
using System.Web.Mvc;

namespace AmusementParkMogul2.Services
{
    public class InvestorService
    {
        private readonly HttpClient _httpClient;

        public InvestorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Investor>> GetInvestorDataAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5253/api/investorapi");
            response.EnsureSuccessStatusCode();

            var investorData = await response.Content.ReadFromJsonAsync<List<Investor>>();
            return investorData;
        }
    } 
}
