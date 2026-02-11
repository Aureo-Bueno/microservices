using Discount.API.Domain.Entities;

namespace Discount.API.Application.Interfaces
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}
