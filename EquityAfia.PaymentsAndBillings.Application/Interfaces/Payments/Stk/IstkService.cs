using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces.Payments.Stk
{
    public interface  IStkService
    {
        Task<Payment> MakeStkPaymentAsync(int billingId, string mobileNumber);
    }
    _configuration = configuration;
        _context = context;
}
