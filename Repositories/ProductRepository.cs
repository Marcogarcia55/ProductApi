using Dapper;
using Microsoft.Data.SqlClient;
using ProductApi.Models;
using System.Data;

namespace ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Product>("sp_GetAllProducts", commandType: CommandType.StoredProcedure);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Product?>(
                "sp_GetProductById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }


        public async Task<int> AddAsync(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "sp_AddProduct",
                new { product.Name, product.Price, product.Stock },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "sp_UpdateProduct",
                new { product.Id, product.Name, product.Price, product.Stock },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "sp_DeleteProduct",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }
    }
}
