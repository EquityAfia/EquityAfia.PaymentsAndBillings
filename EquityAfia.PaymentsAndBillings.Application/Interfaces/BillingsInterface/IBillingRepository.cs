using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing
{
    public interface IBillingRepository
    {
        Task AddAsync(BillingDto billing); // Add a billing entity
        Task<Billing> GetBillingByIdAsync(int billingId); // Get a billing entity by ID
    }
}
