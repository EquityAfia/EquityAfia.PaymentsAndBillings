// Application/Services/BillingService.cs
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System.Threading.Tasks;

public class BillingService : IBillingService
{
    public async Task<BillingDto> AddBillingWithServicesAsync(BillingDto billingDto)
    {
        // Implement the service logic here

        // Example: Map BillingDto to Billing entity, perform business logic, and return result
        var billing = new Billing
        {
            BillingId = billingDto.BillingId,
            CustomerName = billingDto.CustomerName,
            CustomerId = billingDto.CustomerId,
            CustomerEmail = billingDto.CustomerEmail,
            CustomerPhoneNumber = billingDto.CustomerPhoneNumber,
            AppointmentId = billingDto.AppointmentId,
            AmountBilled = billingDto.AmountBilled,
            PayBill = billingDto.PayBill,
            AccNo = billingDto.AccNo,
            PaymentStatus = billingDto.PaymentStatus,
            Services = billingDto.Services.Select(s => new Service
            {
                ServiceId = s.ServiceId,
                Quantity = s.Quantity,
                AmountCharged = s.AmountCharged
            }).ToList(),
            Products = billingDto.Products.Select(p => new Product
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity,
                Price = p.Price
            }).ToList()
        };

        // Save billing to database (repository pattern could be used here)
        // Example: await _billingRepository.AddAsync(billing);

        return billingDto;
    }
}
