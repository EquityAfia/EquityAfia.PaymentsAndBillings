// Application/Interfaces/IPaymentService.cs
using System.Threading.Tasks;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IPaymentService
    {
        Task ConfirmPaymentAsync(PaymentConfirmationRequest request);
      
    }
}
