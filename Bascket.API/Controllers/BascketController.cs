using Bascket.Application.Interfaces;
using Bascket.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bascket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BascketController : ControllerBase
    {
        private readonly IBascketRepository _bascketRepository;
        private readonly IDiscountService _discountService;
        public BascketController(IBascketRepository bascketRepository, IDiscountService discountService)
        {
            _bascketRepository = bascketRepository ?? throw new ArgumentException(nameof(bascketRepository));
            _discountService = discountService ?? throw new ArgumentException(nameof(discountService));
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> Get([FromRoute] string userName)
        {
            ShoppingCart bascket = await _bascketRepository.GetBascket(userName);

            return Ok(bascket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ShoppingCart shoppingCart)
        {
            foreach (ShoppingCartItem item in shoppingCart.Items)
            {
                var coupon = await _discountService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            return Ok(await _bascketRepository.UpdateBascket(shoppingCart));
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> Delete([FromRoute] string userName)
        {
            await _bascketRepository.DeleteBascket(userName);
            return Ok();
        }
    }
}
