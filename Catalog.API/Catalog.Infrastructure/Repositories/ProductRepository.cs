using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProducRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
           await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, productId);

            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public async Task<Product> GetProduct(Guid productId)
        {
            return await _context.Products.Find(p => p.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string productName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, productName);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
           ReplaceOneResult updateResult = await _context.Products.ReplaceOneAsync( filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
