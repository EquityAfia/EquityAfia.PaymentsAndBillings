using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.SharedContract.SharedDtos;
using System.Net.Http.Json;


namespace EquityAfia.PaymentsAndBillings.Application.Services.BillingService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _httpClient;

        public AppointmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IEnumerable<ChargeDto>> GetAppointmentChargesByCustomerIdAsync(string customerId)
        {
            var response = await _httpClient.GetAsync($"http://appointmentbooking/api/customers/{customerId}/appointments/charges");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ChargeDto>>();
        }
    }
}