using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Payments.Stk;
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
    }
}
