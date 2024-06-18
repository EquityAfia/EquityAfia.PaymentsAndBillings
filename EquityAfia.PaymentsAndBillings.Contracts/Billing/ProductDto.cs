using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Contracts
{
    public class ProductDto
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}