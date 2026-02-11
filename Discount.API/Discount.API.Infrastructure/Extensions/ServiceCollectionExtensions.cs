using Discount.API.Application.Interfaces;
using Discount.API.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.API.Infrastructure.Extensions
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
