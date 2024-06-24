using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing
{
    public interface IBillingRepository
    {
        
        Task AddAsync(Domain.Contracts.Billing billing);
        Task<BillingDto> GetBillingDtoByIdAsync(int billingId); // Get a billing entity by ID
    }
}
