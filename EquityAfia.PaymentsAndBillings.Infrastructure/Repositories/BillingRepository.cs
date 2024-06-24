using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly ApplicationDbContext _context;

        public BillingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Billing billing)
        {
            await _context.Billings.AddAsync(billing);
            await _context.SaveChangesAsync();
        }

        public async Task<Billing> GetBillingByIdAsync(int billingId)
        {
            return await _context.Billings.FirstOrDefaultAsync(b => b.BillingId == billingId);
        }
    }
}
