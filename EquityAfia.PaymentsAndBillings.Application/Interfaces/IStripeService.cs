using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{
    public interface IStripeService
    {
        Task<PaymentIntent> CreatePaymentIntent(decimal amount, string currency, string paymentMethod, int billingId, string customerId, string customerName, string customerEmail);
        Task<PaymentIntent> ConfirmPaymentIntent(string paymentIntentId, string paymentMethod);
    }
}