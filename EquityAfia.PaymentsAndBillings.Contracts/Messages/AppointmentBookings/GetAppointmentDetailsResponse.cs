using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts.Messages.AppointmentBookings
{
  public   class GetAppointmentDetailsResponse
    {
        public int AppointmentId { get; set; }
        public int Quantity { get; init; }
        public decimal AmountCharged { get; init; }

    }
}
