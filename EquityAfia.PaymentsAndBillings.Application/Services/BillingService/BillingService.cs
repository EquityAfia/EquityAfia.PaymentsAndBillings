﻿


using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
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
    }
}






































































