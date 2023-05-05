using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProducRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid productId);
        Task<IEnumerable<Product>> GetProductsByName(string productName);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Guid productId);
    }
}
