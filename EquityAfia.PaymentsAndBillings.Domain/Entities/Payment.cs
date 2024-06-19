// Domain/Entities/Payment.cs
using System;

namespace EquityAfia.PaymentsAndBillings.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int AmountPaid { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Products { get; set; }
        public string Services { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? BillingId { get; set; }
        public Billing Billing { get; set; }
    }
}
