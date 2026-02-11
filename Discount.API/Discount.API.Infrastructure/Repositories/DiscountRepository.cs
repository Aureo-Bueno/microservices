using Dapper;
using Discount.API.Application.Interfaces;
using Discount.API.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.API.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }

        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            NpgsqlConnection connection = GetConnection();

            Coupon coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName});
        
            if(coupon is null)
            {
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
            }

            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            NpgsqlConnection connection = GetConnection();

            var create = await connection.ExecuteAsync
                ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            if (create == 0)
                return false;

            return true;

        }
        
        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            NpgsqlConnection connection = GetConnection();

            var update = await connection.ExecuteAsync
               ("UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE Id = @Id",
               new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

            if (update == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            NpgsqlConnection connection = GetConnection();

            var delete = await connection.ExecuteAsync
              ("DELETE FROM Coupon WHERE ProductName = @ProductName",
              new { ProductName = productName });

            if (delete == 0)
                return false;

            return true;
        }

    }
}
