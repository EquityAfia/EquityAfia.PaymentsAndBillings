﻿using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.UserManagement;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.CommodityMedicineManagement;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.AppointmentBooking;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using MassTransit;
using System;
using System.Linq;
using System.Threading.Tasks;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.AppointmentBookings;

namespace EquityAfia.PaymentsAndBillings.Application.Services.BillingService
{
    public class BillingService : IBillingService
    {
        private readonly IRequestClient<GetUserDetailsRequest> _userDetailsClient;
        private readonly IRequestClient<GetProductDetailsRequest> _productDetailsClient;
        private readonly IRequestClient<GetAppointmentDetailsRequest> _appointmentDetailsClient;
        private readonly IBillingRepository _billingRepository;

        public BillingService(
            IRequestClient<GetUserDetailsRequest> userDetailsClient,
            IRequestClient<GetProductDetailsRequest> productDetailsClient,
            IRequestClient<GetAppointmentDetailsRequest> appointmentDetailsClient,
            IBillingRepository billingRepository)
        {
            _userDetailsClient = userDetailsClient;
            _productDetailsClient = productDetailsClient;
            _appointmentDetailsClient = appointmentDetailsClient;
            _billingRepository = billingRepository;
        }

        public async Task<BillingDto> AddBillingWithServicesAsync(BillingDto billingDto)
        {
            // Retrieve user details
            var userResponse = await _userDetailsClient.GetResponse<GetUserDetailsResponse>(new { billingDto.CustomerId });
            var userDto = userResponse.Message;
            if (userDto == null)
            {
                throw new Exception("User not found");
            }

            // Retrieve products
            var productResponse = await _productDetailsClient.GetResponse<GetProductDetailsResponse>(new { billingDto.CustomerId });
            var products = productResponse.Message.Products;

            // Retrieve appointment charges
            var appointmentResponse = await _appointmentDetailsClient.GetResponse<GetAppointmentDetailsResponse>(new { billingDto.CustomerId });
            var charges = appointmentResponse.Message.AppointmentCharges;

            // Calculate total amount billed
            billingDto.AmountBilled = (int)(products.Sum(p => p.Price * p.Quantity) + charges.Sum(c => c.Amount));

            // Create Billing enti
            var billing = new Billing
            {
                BillingId = billingDto.BillingId,
                CustomerName = userDto.Name,
                CustomerId = billingDto.CustomerId,
                CustomerEmail = userDto.Email,
                CustomerPhoneNumber = userDto.PhoneNumber,
                AppointmentId = billingDto.AppointmentId,
                AmountBilled = billingDto.AmountBilled,
                PayBill = billingDto.PayBill,
                AccNo = billingDto.AccNo,
                PaymentStatus = billingDto.PaymentStatus,
                Services = billingDto.Services.Select(s => new Service
                {
                    ServiceId = s.ServiceId,
                    Quantity = s.Quantity,
                    AmountCharged = s.AmountCharged
                }).ToList(),
                Products = products.Select(p => new Product
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                    Price = (int)p.Price
                }).ToList()
            };

            // Save billing to database
            await _billingRepository.AddAsync(billing);

            return billingDto;
        }
    }
}
