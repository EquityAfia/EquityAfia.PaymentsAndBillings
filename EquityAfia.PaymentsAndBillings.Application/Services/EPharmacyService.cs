using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Services
{
    public class EPharmacyService : IEPharmacyService
    {
        private readonly HttpClient _httpClient;

        public EPharmacyService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IEnumerable<Product>> GetProductsByCustomerIdAsync(string customerId)
        {
            var response = await _httpClient.GetAsync($"http://epharmacy/api/customers/{customerId}/products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
        }
    }
}
