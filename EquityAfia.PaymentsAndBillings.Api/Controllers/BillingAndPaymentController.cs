using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Payments.Stk;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Payment.Card;
using EquityAfia.PaymentsAndBillings.Contracts.Payment.Stk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingAndPaymentController : ControllerBase
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IBillingService _billingService;
        private readonly IPaymentService _paymentService;
        private readonly IStripeService _stripeService;
        private readonly IStkService _stkService;

        public BillingAndPaymentController(IBillingRepository billingRepository, IBillingService billingService, IPaymentService paymentService, IStripeService stripeService, IStkService stkService)
        {
            _billingRepository = billingRepository;
            _billingService = billingService;
            _paymentService = paymentService;
            _stripeService = stripeService;
            _stkService = stkService;
        }

        [HttpGet("billings")]
        public async Task<IActionResult> GetAllBillings()
        {
            try
            {
                var billings = await _billingRepository.GetAllBillingsAsync();
                if (billings == null || billings.Count == 0)
                    return NotFound(new { message = "No billings found" });

                return Ok(billings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("billing")]
        public async Task<IActionResult> AddBillingWithServices([FromBody] BillingDto billingDto)
        {
            if (billingDto == null)
                return BadRequest("Billing data is required");

            try
            {
                var result = await _billingService.AddBillingWithServicesAsync(billingDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("payment/confirm")]
        public async Task<IActionResult> ConfirmPayment([FromBody] PaymentConfirmationRequest request)
        {
            if (request == null)
                return BadRequest("Request data is required");

            try
            {
                await _paymentService.ConfirmPaymentAsync(request);
                return Ok(new { message = "Payment confirmed successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("stripe/create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] CreateStripePaymentIntentRequest request)
        {
            if (request == null)
                return BadRequest("Request data is required");

            try
            {
                var paymentIntent = await _stripeService.CreatePaymentIntent(request.Amount, request.Currency, request.PaymentMethod, request.BillingId, request.CustomerId, request.CustomerName, request.CustomerEmail);
                return Ok(new { paymentIntentId = paymentIntent.Id, clientSecret = paymentIntent.ClientSecret });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("stripe/confirm-payment-intent")]
        public async Task<IActionResult> ConfirmPaymentIntent([FromBody] ConfirmStripePaymentIntentRequest request)
        {
            if (request == null)
                return BadRequest("Request data is required");

            try
            {
                var paymentIntent = await _stripeService.ConfirmPaymentIntent(request.PaymentIntentId, request.PaymentMethod);
                return Ok(new { paymentIntentId = paymentIntent.Id, status = paymentIntent.Status });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("payment/stk/{billingId}")]
        public async Task<IActionResult> MakeStkPayment([FromRoute] int billingId, [FromBody] StkPayment request)
        {
            if (request == null)
                return BadRequest("Request data is required");

            try
            {
                var payment = await _stkService.MakeStkPaymentAsync(billingId, request.MobileNumber);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
