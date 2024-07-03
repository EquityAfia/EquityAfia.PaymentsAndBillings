using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Services.BillingService
{
    public class BillingService : IBillingService
    {
        private readonly IUserService _userService;
        private readonly IEPharmacyService _ePharmacyService;
        private readonly IAppointmentService _appointmentService;
        private readonly IBillingRepository _billingRepository;

        public BillingService(
            IUserService userService,
            IEPharmacyService ePharmacyService,
            IAppointmentService appointmentService,
            IBillingRepository billingRepository)
        {
            _userService = userService;
            _ePharmacyService = ePharmacyService;
            _appointmentService = appointmentService;
            _billingRepository = billingRepository;
        }

        public async Task<BillingDto> AddBillingWithServicesAsync(BillingDto billingDto)
        {
            // Retrieve user details
            var UserDto = await _userService.GetUserByIdAsync(billingDto.CustomerId);
            if (UserDto == null)
            {
                throw new Exception("User not found");
            }

            // Retrieve products from E-Pharmacy
            var products = await _ePharmacyService.GetProductsByCustomerIdAsync(billingDto.CustomerId);
            // Retrieve appointment charges
            var charges = await _appointmentService.GetAppointmentChargesByCustomerIdAsync(billingDto.CustomerId);

            // Calculate total amount billed
            billingDto.AmountBilled = products.Sum(p => p.Price * p.Quantity) + charges.Sum(c => c.Amount);


            // Create Billing entity
            var billing = new Billing
            {
                BillingId = billingDto.BillingId,
                CustomerName = UserDto.Name,
                CustomerId = billingDto.CustomerId,
                CustomerEmail = UserDto.Email,
                CustomerPhoneNumber = UserDto.PhoneNumber,
                AppointmentId = billingDto.AppointmentId,
                AmountBilled = (int)billingDto.AmountBilled,
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
                    Price = p.Price
                }).ToList()
            };

            // Save billing to database
            await _billingRepository.AddAsync(billing);

            return billingDto;
        }

        public async Task<UserDto> GetUserByIdAsync(string userId)
        {
            // Mock implementation - replace with actual data retrieval logic
            return await Task.FromResult(new UserDto
            {
                UserId = userId,
                
                
                
            
        
    

