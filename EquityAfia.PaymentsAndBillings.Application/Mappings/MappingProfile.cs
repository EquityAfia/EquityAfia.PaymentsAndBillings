using AutoMapper;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define your mappings here
            CreateMap<Billing, BillingDto>().ReverseMap();
           
        }
    }
}
