// Application/Interfaces/IBillingRepository.cs
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System.Threading.Tasks;

public interface IBillingRepository
{
    Task AddAsync(Billing billing);
    // Other CRUD methods
}
