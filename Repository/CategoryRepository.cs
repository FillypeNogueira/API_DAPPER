using API_DAPPER.Models.Requests;
using API_DAPPER.Models.Responses;
using API_DAPPER.Repository.Interface;
using Dapper;
using Npgsql;

namespace API_DAPPER.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetConnectionString("NpgsqlConnection");
        }

        public async Task<bool> AddCategoryAsync(CategoryRequest request)
        {
            string sql = @"insert into Category(Name, Status) values(@Name, @Status)";

            using(var con = new NpgsqlConnection(connectionString))
            return await con.ExecuteAsync(sql, request) > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            string sql = @"delete from Category where id = @id;";

            using(var con = new NpgsqlConnection(connectionString))
            return await con.ExecuteAsync(sql, new {id = id}) > 0; 
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            string sql = @"select c.id, c.name, c.status from Category c join Product p on p.Id = c.Id;";

            using(var con = new NpgsqlConnection(connectionString))
            return await con.QueryAsync<CategoryResponse>(sql);
        }

        public async Task<CategoryResponse> GetCategoryAsync(int id)
        {
            string sql = @"select c.name, c.status from Category c join Product p on p.Id = c.Id where c.Id = @id;";

            using(var con = new NpgsqlConnection(connectionString))
            return await con.QueryFirstOrDefaultAsync<CategoryResponse>(sql, new{id = id});
        }

        public async Task<bool> UpdateCategoryAsync(CategoryRequest request, int id)
        {
            string sql = @"update from Category set Name = @Name, Status = @Status where Id = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("Name", request.Name);
            parameters.Add("Status", request.Status);
            parameters.Add("Id", id);
            
            using(var con = new NpgsqlConnection(connectionString))
            return await con.ExecuteAsync(sql, request) > 0;
        }
    }
}