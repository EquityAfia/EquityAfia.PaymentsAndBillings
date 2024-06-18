using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IBillingService
    {
        Task<BillingDto> AddBillingWithServicesAsync(BillingDto billingDto);
    }
}
