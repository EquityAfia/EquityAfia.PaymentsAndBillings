using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly List<Billing> _billingStore = new List<Billing>();

        public async Task<Billing> AddAsync(Billing billing)
        {
            _billingStore.Add(billing);
            await Task.CompletedTask; // Simulate async operation
            return billing;
        }
    }
}
