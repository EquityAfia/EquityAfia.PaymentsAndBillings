using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts.Payment.Card
{
    public class ConfirmStripePaymentIntentRequest
    {
        public string PaymentIntentId { get; set; }
        public string PaymentMethod { get; set; }
    }
}
