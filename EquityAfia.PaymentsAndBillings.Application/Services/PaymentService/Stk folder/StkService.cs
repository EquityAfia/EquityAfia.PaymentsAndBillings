// Application/Services/PaymentService/StkFolder/StkService.cs
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Payments.Stk;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Services.PaymentService.StkFolder
{
    public class StkService : IStkService
    {
        private readonly IConfiguration _configuration;
        private readonly IBillingRepository _billingRepository;
        private readonly IPaymentRepository _paymentRepository;

        public StkService(IConfiguration configuration, IBillingRepository billingRepository, IPaymentRepository paymentRepository)
        {
            _configuration = configuration;
            _billingRepository = billingRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> MakeStkPaymentAsync(int billingId, string mobileNumber)
        {
            var billing = await _billingRepository.GetBillingByIdAsync(billingId);
            if (billing == null)
            {
                throw new Exception("Billing not found");
            }

            var amountToPay = billing.AmountBilled;


