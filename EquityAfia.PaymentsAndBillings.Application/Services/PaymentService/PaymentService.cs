using System;
using System.Threading.Tasks;
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;

namespace EquityAfia.PaymentsAndBillings.Application.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task ConfirmPaymentAsync(PaymentConfirmationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            // Check if the payment already exists by transaction ID
            var existingPayment = await _paymentRepository.GetPaymentByTransactionIdAsync(request.TransactionId);
            if (existingPayment != null)
                throw new InvalidOperationException("Payment with the same transaction ID already exists.");

            // Create a new Payment entity
            var payment = new Payment
            {
                TransactionId = request.TransactionId,
                AmountPaid = request.Amount,
                BillingId = request.BillingId,
                CreatedAt = DateTime.UtcNow,
                CustomerId = "",  // Assuming CustomerId will be set elsewhere
                CustomerName = "", // Assuming CustomerName will be set elsewhere
                CustomerEmail = "", // Assuming CustomerEmail will be set elsewhere
                Products = "", // Assuming Products will be set elsewhere
                Services = "", // Assuming Services will be set elsewhere
                PaymentMethod = "", // Assuming PaymentMethod will be set elsewhere
                PaymentStatus = "Confirmed" // Set a default status or derive based on logic
            };

            // Add the new payment to the repository
            _paymentRepository.Add(payment);

            // Save changes to the database
            await _paymentRepository.SaveChangesAsync();
        }
    }
}
