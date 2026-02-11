using Catalog.Domain.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
