namespace RapidPay.Web.Application
{
    public interface IUniversalFeeExchangeService
    {
        decimal GetCurrentFee();
    }
    public class UniversalFeeExchangeService : IUniversalFeeExchangeService
    {
        private readonly object _lock = new();
        private decimal _currentFee = 1.0m;
        private DateTime _lastUpdated = DateTime.UtcNow;
        private readonly Random _random = new();

        public decimal GetCurrentFee()
        {
            lock (_lock)
            {
                if ((DateTime.UtcNow - _lastUpdated).TotalHours >= 1)
                {
                    decimal factor = (decimal)_random.NextDouble() * 2;
                    _currentFee *= factor;
                    _lastUpdated = DateTime.UtcNow;
                }

                return _currentFee;
            }
        }
    }
}
