﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts.Messages.UserManagement
{
    internal class GetUserDetailsResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; }

    }
}