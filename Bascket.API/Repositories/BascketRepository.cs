using Bascket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Bascket.API.Repositories
{
    public class BascketRepository : IBascketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BascketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentException(nameof(redisCache));
        }

        public async Task<ShoppingCart> GetBascket(string userName)
        {
            string bascket = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(bascket))
                return null;

            return JsonSerializer.Deserialize<ShoppingCart>(bascket);
        }

        public async Task<ShoppingCart> UpdateBascket(ShoppingCart shoppingCart)
        {
            await _redisCache.SetStringAsync(shoppingCart.UserName, JsonSerializer.Serialize(shoppingCart));
          
            return await GetBascket(shoppingCart.UserName);
        }
        public async Task DeleteBascket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

     

       
    }
}
