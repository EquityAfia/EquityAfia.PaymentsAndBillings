using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IBillingService
    {
        Task<BillingDto> AddBillingWithServicesAsync(BillingDto billingDto);
    }
}
