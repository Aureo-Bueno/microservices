using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICatalogContext, CatalogContext>();
            services.AddScoped<IProducRepository, ProductRepository>();

            return services;
        }
    }
}
