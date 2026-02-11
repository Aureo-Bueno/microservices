using AutoMapper;
using Discount.Grpc.Domain.Entities;
using Discount.Grpc.Service;

namespace Discount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
