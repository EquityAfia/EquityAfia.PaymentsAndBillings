using EquityAfia.SharedContract.SharedDtos;

namespace EquityAfia.SharedContract.Messages.UserManagement
{
    public class GetAppointmentDetailsResponse
    {
        public List<ChargeDto> AppointmentCharges { get; set; }
    }
}

