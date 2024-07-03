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

      
        
           
            
            
                
            

            
            
            
          
            
          


            
            
            
                
                
                
                
                
                
                
                
                
                    
                    
                    
                
                
                
                    
                    
                    
                
           
            
            

            
        

        
        
           
            
            
                
                
                
            
        
    

