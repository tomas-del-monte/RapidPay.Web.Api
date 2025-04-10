using Microsoft.EntityFrameworkCore;
using RapidPay.Domain.Models;
using RapidPay.Web.Infrastructure;

namespace RapidPay.Web.Application
{
    public class CardService
    {
        private readonly AppDbContext _context;
        private IUniversalFeeExchangeService _ufeService;

        public CardService(AppDbContext context, IUniversalFeeExchangeService universalFeeExchangeService)
        {
            _context = context;
            _ufeService = universalFeeExchangeService;
        }

        public async Task<Card> CreateCardAsync()
        {
            var card = new Card
            {
                CardNumber = GenerateCardNumber(),
                Balance = 0
            };

            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<bool> PayAsync(string cardNumber, decimal amount)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
            if (card == null || card.Balance < amount)
                return false;

            var fee = _ufeService.GetCurrentFee();
            card.Balance -= amount * fee;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal?> GetBalanceAsync(string cardNumber)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
            return card?.Balance;
        }

        private string GenerateCardNumber()
        {
            var random = new Random();
            return string.Concat(Enumerable.Range(0, 15).Select(_ => random.Next(10).ToString()));
        }
    }
}
