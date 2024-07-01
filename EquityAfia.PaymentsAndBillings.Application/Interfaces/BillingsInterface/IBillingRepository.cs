using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing
{
    public interface IBillingRepository
    {
        Task AddAsync(EquityAfia.PaymentsAndBillings.Domain.Entities.Billing billing);
        Task<EquityAfia.PaymentsAndBillings.Domain.Entities.Billing> GetBillingByIdOrAppointmentIdAsync(int billingId, int appointmentId);
        Task<EquityAfia.PaymentsAndBillings.Domain.Entities.Billing> GetBillingByIdAsync(int billingId);
        Task GetAllBillingsAsync();
    }
}
