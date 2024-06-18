using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts.Billing
{
    public class ChargeDto
    {
        public string ChargeId { get; set; }
        public decimal Amount { get; set; }
    }
}