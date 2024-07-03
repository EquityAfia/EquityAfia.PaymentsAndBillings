


using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.UserManagement;
using MassTransit;

namespace EquityAfia.PaymentsAndBillings.Application.Services.BillingService
{
    public class BillingService : IBillingService
    {
        private readonly IRequestClient<GetUserDetailsRequest> _userClient;

    }
}






































































