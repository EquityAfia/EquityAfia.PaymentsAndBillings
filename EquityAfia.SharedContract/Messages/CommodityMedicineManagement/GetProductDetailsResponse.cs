using EquityAfia.SharedContract.SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.SharedContract.Messages.UserManagement
{
    public class GetProductDetailsResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}

