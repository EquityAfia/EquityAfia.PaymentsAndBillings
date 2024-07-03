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
                
                
                
                
                
                
                
                
                
                    
                    
                    
                
                
                
                    
                    
                    
                
           
            
            

            
        

        
        
           
            
            
                
                
                
            
        
    

