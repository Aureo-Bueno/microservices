using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces
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
