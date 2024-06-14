using System.Collections.Generic;

namespace EquityAfia.PaymentsAndBillings.Domain.Entities
{
    public class Billing
    {
        public string BillingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string AppointmentId { get; set; }
        public int AmountBilled { get; set; }
        public bool PayBill { get; set; }
        public int AccNo { get; set; }
        public string PaymentStatus { get; set; }

        public List<Service> Services { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Service
    {
        public string ServiceId { get; set; }
        public int Quantity { get; set; }
        public int AmountCharged { get; set; }

        public string BillingId { get; set; }
        public Billing Billing { get; set; }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public string BillingId { get; set; }
        public Billing Billing { get; set; }
    }
}
