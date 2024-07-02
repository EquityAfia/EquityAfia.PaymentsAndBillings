using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts.Messages.CommodityMedicineManagement
{
    public class GetProductDetailsResponse
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
