namespace EquityAfia.PaymentsAndBillings.Contracts.Billing
{
    public record BillingDto
    {
        public string BillingId { get; init; }
        public string CustomerName { get; init; }
        public string CustomerId { get; init; }
        public string CustomerEmail { get; init; }
        public string CustomerPhoneNumber { get; init; }
        public string AppointmentId { get; init; }
        public decimal AmountBilled { get; set; } // Changed from int to decimal
        public bool PayBill { get; init; }
        public int AccNo { get; init; }
        public string PaymentStatus { get; init; }
        public List<ServiceDto> Services { get; init; }
        public List<ProductDto> Products { get; init; }
    }

    public record ServiceDto
    {
        public string ServiceId { get; init; }
        public int Quantity { get; init; }
        public int AmountCharged { get; init; }
    }

    public record ProductDto
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
