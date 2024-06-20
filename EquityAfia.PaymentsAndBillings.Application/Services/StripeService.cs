using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Services
{
    public class StripeService : IStripeService
    {
        private readonly string _stripeSecretKey;
        private readonly string _stripeCheckoutSuccessUrl; // Add this field

        public StripeService(IConfiguration configuration)
        {
            _stripeSecretKey = configuration["Stripe:SecretKey"];
            _stripeCheckoutSuccessUrl = configuration["Stripe:CheckoutSuccessUrl"]; // Load success URL from configuration
            StripeConfiguration.ApiKey = _stripeSecretKey;
        }

        public async Task<PaymentIntent> CreatePaymentIntent(decimal amount, string currency, string paymentMethod, int billingId, string customerId, string customerName, string customerEmail)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100), // Stripe uses the smallest currency unit (cents)
                Currency = currency,
                PaymentMethodTypes = new List<string> { paymentMethod },
                PaymentMethod = paymentMethod,
                ConfirmationMethod = "manual",
                Confirm = true,
                Metadata = new Dictionary<string, string>
                {
                    { "BillingId", billingId.ToString() },
                    { "CustomerId", customerId },
                    { "CustomerName", customerName },
                    { "CustomerEmail", customerEmail }
                }
            };

            // Set return_url for ideal and sofort payment methods if needed
            if (paymentMethod == "ideal" || paymentMethod == "sofort")
            {
                options.ReturnUrl = _stripeCheckoutSuccessUrl;
            }

            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }

        public async Task<PaymentIntent> ConfirmPaymentIntent(string paymentIntentId, string paymentMethod)
        {
            var service = new PaymentIntentService();
            var options = new PaymentIntentConfirmOptions
            {
                PaymentMethod = paymentMethod
            };
            return await service.ConfirmAsync(paymentIntentId, options);
        }
    }
}
