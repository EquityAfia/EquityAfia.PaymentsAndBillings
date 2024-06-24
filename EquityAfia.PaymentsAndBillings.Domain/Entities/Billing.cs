using System.Collections.Generic;

namespace EquityAfia.PaymentsAndBillings.Domain.Entities
{
    public class Billing
    {
        public int BillingId { get; set; } // Primary Key
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int AppointmentId { get; set; }
        public int AmountBilled { get; set; }
        public bool PayBill { get; set; }
        public int AccNo { get; set; }
        public string PaymentStatus { get; set; }

        // Navigation Properties
        public List<Service> Services { get; set; }
        public List<Product> Products { get; set; }

        public static implicit operator Billing(PaymentsAndBillings.Contracts.Billing.BillingDto v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Billing(PaymentsAndBillings.Contracts.Billing.BillingDto v)
        {
            throw new NotImplementedException();
        }
    }

    public class Service
    {
        public int ServiceId { get; set; } // Primary Key (assuming)
        public int Quantity { get; set; }
        public decimal AmountCharged { get; set; }

        public int BillingId { get; set; } // Foreign Key
        public Billing Billing { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; } // Primary Key (assuming)
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int BillingId { get; set; } // Foreign Key
        public Billing Billing { get; set; }
    }
}
