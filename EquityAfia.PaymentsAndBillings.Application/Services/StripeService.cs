using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Services
{
    public class StripeService : IStripeService
    {
        private readonly IConfiguration _configuration;

        public StripeService(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }

        public async Task<PaymentIntent> CreatePaymentIntent(decimal amount, string currency, string paymentMethod)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = currency,
                PaymentMethodTypes = new List<string> { paymentMethod },
            };

            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);
            return paymentIntent;
        }

        public async Task<PaymentIntent> ConfirmPaymentIntent(string paymentIntentId)
        {
            var service = new PaymentIntentService();
            var paymentIntent = await service.ConfirmAsync(paymentIntentId);
            return paymentIntent;
        }
    }
}
