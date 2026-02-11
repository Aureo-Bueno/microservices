using Bascket.Application.Interfaces;
using DomainDiscount = Bascket.Domain.Entities.Discount;
using Discount.Grpc.Service;

namespace Bascket.Infrastructure.GrpcServices
{
    public class DiscountGrpsService : IDiscountService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpsService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }

        public async Task<DomainDiscount> GetDiscount(string productName)
        {
            GetDiscountRequest discountRequest = new GetDiscountRequest { ProductName = productName };

            CouponModel coupon = await _discountProtoService.GetDiscountAsync(discountRequest);

            return new DomainDiscount
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount,
            };
        }
    }
}
