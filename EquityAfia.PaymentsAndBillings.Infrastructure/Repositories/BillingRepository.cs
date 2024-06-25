using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using EquityAfia.PaymentsAndBillings.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly EquityAfiaDbContext _context;

        public BillingRepository(EquityAfiaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Billing billing)
        {
            await _context.Billings.AddAsync(billing);
            await _context.SaveChangesAsync();
        }

        public async Task<Billing> GetBillingByIdOrAppointmentIdAsync(int billingId, int appointmentId)
        {
            return await _context.Billings
                .FirstOrDefaultAsync(b => b.BillingId == billingId || b.AppointmentId == appointmentId);
        }

        public async Task<Billing> GetBillingByIdAsync(int billingId)
        {
            return await _context.Billings
                .FirstOrDefaultAsync(b => b.BillingId == billingId);
        }
    }
}
