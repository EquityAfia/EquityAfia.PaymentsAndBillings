// Infrastructure/Repositories/BillingRepository.cs
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using EquityAfia.PaymentsAndBillings.Infrastructure.Data;
using System.Threading.Tasks;

public class BillingRepository : IBillingRepository
{
    private readonly EquityAfiaDbContext _context;

    public BillingRepository(EquityAfiaDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Billing billing)
    {
        await _context.Billings.AddAsync(billing);
        await _context.SaveChangesAsync();
    }

    // Other CRUD methods
}
