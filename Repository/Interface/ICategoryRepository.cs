using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_DAPPER.Models.Requests;
using API_DAPPER.Models.Responses;

namespace API_DAPPER.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryResponse>> GetCategoriesAsync();

        Task<CategoryResponse> GetCategoryAsync(int Id);

        Task<bool> AddCategoryAsync(CategoryRequest request);

        Task<bool> UpdateCategoryAsync(CategoryRequest request, int id);

        Task<bool> DeleteCategoryAsync(int Id);
        
    }
}