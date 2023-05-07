using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Repositories;
using Discount.Grpc.Service;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscountService> _logger;
        public DiscountService(IDiscountRepository discountRepository, IMapper mapper, ILogger<DiscountService> logger)
        {
            _discountRepository = discountRepository ?? throw new ArgumentException(nameof(discountRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon = await _discountRepository.GetDiscount(request.ProductName);

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName = {request.ProductName} not found"));

            _logger.LogInformation("Discount retrieved for productName: {productName}, Amount: {amount}", coupon.ProductName, coupon.Amount);
           
            CouponModel couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon = _mapper.Map<Coupon>(request.Coupon);
            var createCoupon = await _discountRepository.CreateDiscount(coupon);

            CouponModel couponModel = _mapper.Map<CouponModel>(createCoupon);

            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon = _mapper.Map<Coupon>(request.Coupon);
            var createCoupon = await _discountRepository.UpdateDiscount(coupon);

            CouponModel couponModel = _mapper.Map<CouponModel>(createCoupon);

            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            bool deleteCoupon = await _discountRepository.DeleteDiscount(request.ProductName);

            DeleteDiscountResponse result = new DeleteDiscountResponse
            {
                Success = deleteCoupon
            };

            return result;
        }
    }
}
