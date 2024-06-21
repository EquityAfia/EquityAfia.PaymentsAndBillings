using System.Collections.Generic;
using System.Threading.Tasks;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;

namespace EquityAfia.PaymentsAndBillings.Application.Interfaces
{ 
public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(string userId);
}
}