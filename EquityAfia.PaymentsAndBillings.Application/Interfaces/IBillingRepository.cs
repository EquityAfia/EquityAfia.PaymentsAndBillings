using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IBillingRepository
    {
        Task<Billing> AddAsync(Billing billing);
    }
}
