using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IEPharmacyService
    {
        Task<IEnumerable<Product>> GetProductsByCustomerIdAsync(string customerId);
    }
}
