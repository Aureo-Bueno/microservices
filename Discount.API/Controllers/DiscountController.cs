using Discount.API.Application.Interfaces;
using Discount.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet("{productName}")]
        public async Task<IActionResult> Get([FromBody] string productName)
        {
            Coupon result =  await _discountRepository.GetDiscount(productName);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Coupon coupon)
        {
            var result = await _discountRepository.CreateDiscount(coupon);

            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Coupon coupon)
        {
            var result = await _discountRepository.UpdateDiscount(coupon);

            return result ? Ok() : BadRequest();
        }


        [HttpDelete("{productName}")]
        public async Task<IActionResult> Delete([FromBody] string productName)
        {
            var result = await _discountRepository.DeleteDiscount(productName);

            return result ? Ok() : BadRequest();
        }
    }
}
