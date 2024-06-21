using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Migrations.Repositories
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
