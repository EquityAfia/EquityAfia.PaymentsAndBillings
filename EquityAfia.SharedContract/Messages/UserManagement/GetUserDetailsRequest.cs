using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.SharedContract.Messages.UserManagement

{
    public abstract class GetUserDetailsRequest
    {
        public int UserId { get; set; }
    }
}
