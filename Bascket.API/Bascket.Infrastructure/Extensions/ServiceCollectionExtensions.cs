using Bascket.Application.Interfaces;
using Bascket.Infrastructure.GrpcServices;
using Bascket.Infrastructure.Repositories;
using Discount.Grpc.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bascket.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBascketInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

            services.AddScoped<IBascketRepository, BascketRepository>();
            services.AddScoped<IDiscountService, DiscountGrpsService>();

            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(option =>
                option.Address = new Uri(configuration["GrpcSettings:DiscountUrl"]));

            return services;
        }
    }
}
