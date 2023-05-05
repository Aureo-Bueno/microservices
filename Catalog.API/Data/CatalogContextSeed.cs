using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(x => true).Any();

            if(!existProduct) 
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Description = "Ola",
                    Category= "Teste",
                    Name = "Teste",
                    Image = "Teste",
                    Price = "Valor"

                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Description = "Ola",
                    Category= "Teste",
                    Name = "Teste",
                    Image = "Teste",
                    Price = "Valor"

                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Description = "Ola",
                    Category= "Teste",
                    Name = "Teste",
                    Image = "Teste",
                    Price = "Valor"

                }
            };
        }
    }
}
