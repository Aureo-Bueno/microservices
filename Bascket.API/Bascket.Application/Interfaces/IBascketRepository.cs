using Bascket.Domain.Entities;

namespace Bascket.Application.Interfaces
{
    public interface IBascketRepository
    {
        Task<ShoppingCart> GetBascket(string userName);
        Task<ShoppingCart> UpdateBascket(ShoppingCart shoppingCart);
        Task DeleteBascket(string userName);
    }
}
