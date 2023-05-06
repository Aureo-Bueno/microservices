using Bascket.API.Entities;

namespace Bascket.API.Repositories
{
    public interface IBascketRepository
    {
        Task<ShoppingCart> GetBascket(string userName);
        Task<ShoppingCart> UpdateBascket(ShoppingCart shoppingCart);
        Task DeleteBascket(string userName);
    }
}
