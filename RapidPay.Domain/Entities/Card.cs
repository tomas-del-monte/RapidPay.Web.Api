namespace RapidPay.Domain.Models
{
    public sealed class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
