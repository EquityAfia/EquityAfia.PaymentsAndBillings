namespace EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing
{
    public interface IBillingRepository
    {
        Task AddAsync(Bill billing);
        Task<Billing> GetBillingByIdOrAppointmentIdAsync(int billingId, int appointmentId);
        Task<Billing> GetBillingByIdAsync(int billingId);
    }
}
