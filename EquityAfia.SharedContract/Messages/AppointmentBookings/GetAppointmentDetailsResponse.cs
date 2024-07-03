using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts.Messages.AppointmentBooking
{
    public class GetAppointmentDetailsResponse
    {
        public List<ChargeDto> AppointmentCharges { get; set; }
    }
}

