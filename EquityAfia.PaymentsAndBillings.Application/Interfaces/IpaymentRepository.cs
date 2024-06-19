using EquityAfia.PaymentsAndBillings.Domain.Entities;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentByTransactionIdAsync(string transactionId);
        Task<Billing> GetBillingByIdOrAppointmentIdAsync(int billingId, int appointmentId);
        Task<decimal> GetTotalPaidAmountByBillingIdAsync(int billingId);
        Task SaveChangesAsync();
        void Add(Payment payment);
    }
}
