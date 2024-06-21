// Contracts/Billing/CreateStripePaymentIntentRequest.cs
namespace EquityAfia.PaymentsAndBillings.Contracts.Payment.Card
{
    public class CreateStripePaymentIntentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public int BillingId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}