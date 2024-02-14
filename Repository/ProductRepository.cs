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
        public async Task<bool> AddProductAsync(ProductRequest request)
        {
            string sql = @"insert into Product (name, description, price, status, categoryid) values (@Name, @Description, @Price, @Status, @CategoryId);";
            using(var con = new NpgsqlConnection(connectionString))
            return await con.ExecuteAsync(sql, request) > 0;
        }

        public async Task<bool> DeleteProcuctAsync(int id)
        {
            string sql = @"delete from Product where id = @id;";

            using(var con = new NpgsqlConnection(connectionString))
            return await con.ExecuteAsync(sql, new {id = id}) > 0 ;
        }

        public async Task<ProductResponse> GetProductAsync(int Id)
        {
            string sql = @"select p.id, p.Name, p.Description, p.Price, p.Status, p.CategoryId from Product p join Category c on p.categoryid = c.id where p.id = @id;";
            using(var con = new NpgsqlConnection(connectionString))
            return await con.QueryFirstOrDefaultAsync<ProductResponse>(sql, new {id = Id});
        }

        public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
        {
            string sql = @"SELECT P.Name, P.Description, P.Price, P.Status, C.Id
                           FROM Product P
                           JOIN Category C ON P.CategoryId = C.Id;";
            using(var con = new NpgsqlConnection(connectionString))
            return await con.QueryAsync<ProductResponse>(sql);
        }

        public async Task<bool> UpdateProductAsync(ProductRequest request, int id)
        {
            string sql = @"update Product set name = @Name, price = @Price, description = @Description, status = @Status, categoryid = @CategoryId where id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("name", request.Name);
            parameters.Add("price", request.Price);
            parameters.Add("description", request.Description);
            parameters.Add("status", request.Status);
            parameters.Add("categoryid", request.CategoryId);
            parameters.Add("Id", id);

            using(var con = new NpgsqlConnection(connectionString))
            return await con.ExecuteAsync(sql, parameters) > 0;
        }
    }
}