using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
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

        public BillingAndPaymentController(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
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

        // Other action methods for adding billing, confirming payment, etc.
    }
}
