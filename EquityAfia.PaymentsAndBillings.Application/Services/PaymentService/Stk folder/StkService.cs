using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Payments.Stk;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Services.PaymentService.Stk_folder
{
    public class stkService : IStkService
    {
        private readonly IConfiguration _configuration;
        private readonly EquityAfiaDbContext _context;
        public stkService(IConfiguration configuration, EquityAfiaDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<Payment> MakeStkPaymentAsync(int billingId, string mobileNumber)
        {
            var billing = await _context.Billings.FindAsync(billingId);
            var amountToPay = billing.AmountBilled;
            var transactionId = Guid.NewGuid().ToString();
            var consumerKey = _configuration["Mpesa:ConsumerKey"];
            var auth = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{consumerKey}:{consumerSecret}"));

            var client = new RestClient("https://sandbox.safaricom.co.ke");
            var tokenRequest = new RestRequest("/oauth/v1/generate?grant_type=client_credentials", Method.GET);
            tokenRequest.AddHeader("Authorization", $"Basic {auth}");

            var tokenResponse = await client.ExecuteAsync<TokenResponse>(tokenRequest);
            if (!tokenResponse.IsSuccessful) throw new Exception("Unable to fetch token");

            var token = tokenResponse.Data.AccessToken;
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var phone = mobileNumber.Length > 1 ? mobileNumber.Substring(1) : mobileNumber;
            var shortcode = _configuration["Mpesa:Paybill"];
            var password = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{shortcode}{passkey}{timestamp}"));
            var stkPushRequest = new RestRequest("/mpesa/stkpush/v1/processrequest", Method.POST);
            stkPushRequest.AddHeader("Authorization", $"Bearer {token}");
            stkPushRequest.AddJsonBody(new
            {
                BusinessShortCode = shortcode,
                Password = password,
                Timestamp = timestamp,
                TransactionType = "CustomerPayBillOnline",
                Amount = amountToPay,
                PartyA = $"254{phone}",
                PartyB = shortcode,
                PhoneNumber = $"254{phone}",
                CallBackURL = _configuration["Mpesa:CallbackUrl"],
                TransactionDesc = "Payment"






            }










        }
    }
}
