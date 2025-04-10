using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Web.Application;

namespace RapidPay.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardManagementController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardManagementController(CardService cardService)
        {
            _cardService = cardService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCard()
        {
            var card = await _cardService.CreateCardAsync();
            return Ok(card);
        }

        [Authorize]
        [HttpPost("pay")]
        public async Task<IActionResult> Pay(string cardNumber, decimal amount)
        {
            var result = await _cardService.PayAsync(cardNumber, amount);
            return result ? Ok("Payment successful") : BadRequest("Invalid card or insufficient balance");
        }

        [Authorize]
        [HttpGet("balance/{cardNumber}")]
        public async Task<IActionResult> GetBalance(string cardNumber)
        {
            var balance = await _cardService.GetBalanceAsync(cardNumber);
            return balance.HasValue ? Ok(balance) : NotFound("Card not found");
        }
    }
}
