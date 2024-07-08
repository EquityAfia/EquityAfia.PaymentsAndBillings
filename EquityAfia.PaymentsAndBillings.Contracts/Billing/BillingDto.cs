namespace EquityAfia.PaymentsAndBillings.Contracts.Billing
{
    public record BillingDto
    {
        public required int BillingId { get; init; }
        public required string CustomerName { get; init; }
        public required string CustomerId { get; init; }
        public required string CustomerEmail { get; init; }
        public required string CustomerPhoneNumber { get; init; }
        public int AppointmentId { get; init; }
        public int AmountBilled { get; init; } // Changed from set to init
        public bool PayBill { get; init; }
        public required int AccNo { get; init; }
        public required string PaymentStatus { get; init; }
        public required List<ServiceDto> Services { get; init; }
        public required List<ProductDto> Products { get; init; }
    }

    public record ServiceDto
    {
        public int ServiceId { get; init; }
        public int Quantity { get; init; }
        public int AmountCharged { get; init; }
    }

    public record ProductDto
    {
        public required string ProductId { get; init; }
        public int Quantity { get; init; }
        public int Price { get; init; }
    }
}
