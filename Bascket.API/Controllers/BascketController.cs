using Bascket.API.Entities;
using Bascket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace Bascket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BascketController : ControllerBase
    {
        private readonly IBascketRepository _bascketRepository;
        public BascketController(IBascketRepository bascketRepository)
        {
            _bascketRepository = bascketRepository ?? throw new ArgumentException(nameof(bascketRepository));
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> Get([FromBody] string userName)
        {
            ShoppingCart bascket = await _bascketRepository.GetBascket(userName);

            return Ok(bascket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ShoppingCart shoppingCart)
        {
            return Ok(await _bascketRepository.UpdateBascket(shoppingCart));
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> Delete([FromBody] string userName)
        {
            await _bascketRepository.DeleteBascket(userName);
            return Ok();
        }
    }
}
