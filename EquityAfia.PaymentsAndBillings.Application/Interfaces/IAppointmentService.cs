using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<ChargeDto>> GetAppointmentChargesByCustomerIdAsync(string customerId);
    }
}
