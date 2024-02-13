using API_DAPPER.Models.Requests;
using API_DAPPER.Models.Responses;
using API_DAPPER.Repository.Interface;

namespace API_DAPPER.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<bool> AddCategoryAsync(CategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> GetCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(CategoryRequest request, int Id)
        {
            throw new NotImplementedException();
        }
    }
}