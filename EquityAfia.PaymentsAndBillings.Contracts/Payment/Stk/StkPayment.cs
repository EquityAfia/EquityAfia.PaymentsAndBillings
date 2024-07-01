using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts.Payment.Stk
{
    public class StkPayment
    {
        public required string MobileNumber { get; set; }
        public required int BillingId { get; set; }
    }
}
