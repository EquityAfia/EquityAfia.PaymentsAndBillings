// Infrastructure/Repositories/PaymentRepository.cs
using Microsoft.EntityFrameworkCore;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using EquityAfia.PaymentsAndBillings.Infrastructure.Data;
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly EquityAfiaDbContext _context;

        public PaymentRepository(EquityAfiaDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> GetPaymentByTransactionIdAsync(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentException("Transaction ID cannot be null or empty", nameof(transactionId));

            return await _context.Payments
                .FirstOrDefaultAsync(p => p.TransactionId == transactionId);
        }

        public async Task<Billing> GetBillingByIdOrAppointmentIdAsync(int billingId, int appointmentId)
        {
            return await _context.Billings
                .FirstOrDefaultAsync(b => b.BillingId == billingId || b.AppointmentId == appointmentId);
        }

        public async Task<decimal> GetTotalPaidAmountByBillingIdAsync(int billingId)
        {
            var payments = await _context.Payments
                .Where(p => p.BillingId == billingId)
                .ToListAsync();

            return payments.Sum(p => p.AmountPaid);
        }

        public void Add(Payment payment)
        {
            _context.Payments.Add(payment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        Task<IBillingRepository> IPaymentRepository.GetBillingByIdOrAppointmentIdAsync(int billingId, int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
