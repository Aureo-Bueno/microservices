using Discount.Grpc.Application.Interfaces;
using Discount.Grpc.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Grpc.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDiscountInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            return services;
        }
    }
}
