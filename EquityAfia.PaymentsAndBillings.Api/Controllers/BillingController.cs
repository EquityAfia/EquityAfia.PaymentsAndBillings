// Api/Controllers/BillingController.cs
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BillingController : ControllerBase
{
    private readonly IBillingService _billingService;

    public BillingController(IBillingService billingService)
    {
        _billingService = billingService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBillingWithServices([FromBody] BillingDto billingDto)
    {
        if (billingDto == null)
            return BadRequest("Billing data is required");

        var result = await _billingService.AddBillingWithServicesAsync(billingDto);
        return Ok(result);
    }
}
