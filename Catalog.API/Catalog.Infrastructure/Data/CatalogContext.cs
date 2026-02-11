using Catalog.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            IMongoDatabase database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
