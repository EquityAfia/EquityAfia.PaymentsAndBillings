namespace EquityAfia.PaymentsAndBillings.Contracts.Billing
{
    public class PaymentConfirmationRequest
    {
        public string TransactionId { get; set; }
        public int Amount { get; set; }
        public int BillingId { get; set; }
        public int AppointmentId { get; set; }
    }
}
