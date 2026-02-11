using Bascket.Domain.Entities;

namespace Bascket.Application.Interfaces
{
    public interface IDiscountService
    {
        Task<Discount> GetDiscount(string productName);
    }
}
