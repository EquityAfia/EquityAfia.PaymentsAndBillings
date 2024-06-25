using AutoMapper;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Payments.Stk;
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Text;
using System.Threading.Tasks;
using EquityAfia.PaymentsAndBillings.Domain.Entities;

namespace EquityAfia.PaymentsAndBillings.Application.Services.PaymentService.StkFolder
{
    public class StkService : IStkService
    {
        private readonly IConfiguration _configuration;
        private readonly IBillingRepository _billingRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public StkService(IConfiguration configuration, IBillingRepository billingRepository, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _configuration = configuration;
            _billingRepository = billingRepository;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<Payment> MakeStkPaymentAsync(int billingId, string mobileNumber)
        {
            var billingDto = await _billingRepository.GetBillingByIdAsync(billingId);
            if (billingDto == null)
            {
                throw new Exception("Billing not found");
            }

            var billing = _mapper.Map<Billing>(billingDto);

            var amountToPay = billing.AmountBilled;
            var transactionId = Guid.NewGuid().ToString();
            var consumerKey = _configuration["Mpesa:ConsumerKey"];
            var consumerSecret = _configuration["Mpesa:ConsumerSecret"];
            var passkey = _configuration["Mpesa:Passkey"];
            var auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{consumerKey}:{consumerSecret}"));

            var client = new RestClient("https://sandbox.safaricom.co.ke");
            var tokenRequest = new RestRequest("/oauth/v1/generate?grant_type=client_credentials", Method.Get);
            tokenRequest.AddHeader("Authorization", $"Basic {auth}");

            var tokenResponse = await client.ExecuteAsync<TokenResponse>(tokenRequest);
            if (!tokenResponse.IsSuccessful) throw new Exception("Unable to fetch token");

            var token = tokenResponse.Data.AccessToken;
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var phone = mobileNumber.Length > 1 ? mobileNumber[1..] : mobileNumber;
            var shortcode = _configuration["Mpesa:Paybill"];
            var password = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{shortcode}{passkey}{timestamp}"));
            var stkPushRequest = new RestRequest("/mpesa/stkpush/v1/processrequest", Method.Post);
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
            });

            var stkPushResponse = await client.ExecuteAsync<StkPushResponse>(stkPushRequest);
            if (!stkPushResponse.IsSuccessful) throw new Exception("STK Push failed");

            var payment = new Payment
            {
                BillingId = billing.BillingId,
                AmountToPay = billing.AmountBilled,
                AmountPaid = amountToPay,
                CustomerId = billing.CustomerId,
                CustomerName = billing.CustomerName,
                CustomerEmail = billing.CustomerEmail,
                Products = JsonConvert.SerializeObject(billing.Products), // Serialize list to JSON string
                Services = JsonConvert.SerializeObject(billing.Services), // Serialize list to JSON string
                PaymentMethod = "M-Pesa",
                TransactionId = transactionId,
                PaymentStatus = "Paid"
            };

            _paymentRepository.Add(payment);
            await _paymentRepository.SaveChangesAsync();

            return payment;
        }

        private class TokenResponse
        {
            public string AccessToken { get; set; }
            public string ExpiresIn { get; set; }
        }

        private class StkPushResponse
        {
            public string MerchantRequestID { get; set; }
            public string CheckoutRequestID { get; set; }
            public string ResponseCode { get; set; }
            public string CustomerMessage { get; set; }
        }
    }
}
