


using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.AppointmentBookings;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.CommodityMedicineManagement;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.UserManagement;
using MassTransit;

namespace EquityAfia.PaymentsAndBillings.Application.Services.BillingService
{
    public class BillingService : IBillingService
    {
        private readonly IRequestClient<GetUserDetailsRequest> _userClient;
        private readonly IRequestClient<GetProductDetailsRequest> _productClient;
        private readonly IRequestClient<GetAppointmentDetailsRequest> _appointmentClient;
        private readonly IBillingRepository _billingRepository;

        public BillingService(
            IRequestClient<GetUserDetailsRequest> userClient,
            IRequestClient<GetProductDetailsRequest> productClient,
            IRequestClient<GetAppointmentDetailsRequest> appointmentClient,
             IBillingRepository billingRepository)
        {
            _userClient = userClient;
            _productClient = productClient;
            _appointmentClient = appointmentClient;
            _billingRepository = billingRepository;
        }
        public async Task<BillingDto> AddBillingWithServicesAsync(BillingDto billingDto)
    }
}






































































