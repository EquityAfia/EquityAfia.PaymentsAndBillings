using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentByTransactionIdAsync(string transactionId);
        Task<IBillingRepository> GetBillingByIdOrAppointmentIdAsync(int billingId, int appointmentId);
        Task<decimal> GetTotalPaidAmountByBillingIdAsync(int billingId);
        Task SaveChangesAsync();
        void Add(Payment payment);
    }
}
