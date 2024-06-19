// API/Controllers/BillingAndPaymentController.cs
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BillingAndPaymentController : ControllerBase
{
    private readonly IBillingService _billingService;
    private readonly IPaymentService _paymentService;

    public BillingAndPaymentController(IBillingService billingService, IPaymentService paymentService)
    {
        _billingService = billingService;
        _paymentService = paymentService;
    }

    [HttpPost("billing")]
    public async Task<IActionResult> AddBillingWithServices([FromBody] BillingDto billingDto)
    {
        if (billingDto == null)
            return BadRequest("Billing data is required");

        var result = await _billingService.AddBillingWithServicesAsync(billingDto);
        return Ok(result);
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
}
