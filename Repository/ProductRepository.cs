using API_DAPPER.Models.Requests;
using API_DAPPER.Models.Responses;
using API_DAPPER.Repository.Interface;
using Dapper;
using Npgsql;

namespace API_DAPPER.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("NpgsqlConnection");
        }
        public Task<bool> AddProductAsync(ProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProcuctAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> GetProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
        {
            string sql = @"SELECT P.Name, P.Description, P.Price, P.Status, C.Id
                           FROM Product P
                           JOIN Category C ON P.CategoryId = C.Id;";
            using(var con = new NpgsqlConnection(connectionString))
            return await con.QueryAsync<ProductResponse>(sql);
        }

        public Task<bool> UpdateProductAsync(ProductRequest request, int id)
        {
            throw new NotImplementedException();
        }
    }
}