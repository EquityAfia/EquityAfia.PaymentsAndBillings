using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts.Billing
{// Contracts/Billing/BillingDto.cs
    public record BillingDto
    {
        public string BillingId { get; init; }
        public string CustomerName { get; init; }
        public string CustomerId { get; init; }
        public string CustomerEmail { get; init; }
        public string CustomerPhoneNumber { get; init; }
        public string AppointmentId { get; init; }
        public int AmountBilled { get; init; }
        public bool PayBill { get; init; }
        public int AccNo { get; init; }
        public string PaymentStatus { get; init; }
        public List<ServiceDto> Services { get; init; }
        public List<ProductDto> Products { get; init; }
    }

    public record ServiceDto
    {
        public string ServiceId { get; init; }
        public int Quantity { get; init; }
        public int AmountCharged { get; init; }
    }

    public record ProductDto
    {
        public string ProductId { get; init; }
        public int Quantity { get; init; }
        public int Price { get; init; }
    }
}
