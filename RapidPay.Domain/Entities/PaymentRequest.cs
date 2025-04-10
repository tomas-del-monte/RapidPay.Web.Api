namespace RapidPay.Domain.Models
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
