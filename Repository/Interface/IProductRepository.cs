using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_DAPPER.Models.Requests;
using API_DAPPER.Models.Responses;

namespace API_DAPPER.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductResponse>> GetProductsAsync();

        Task<ProductResponse> GetProductAsync(int Id);

        Task<bool> AddProductAsync(ProductRequest request);

        Task<bool> UpdateProductAsync(ProductRequest request, int id);

        Task<bool> DeleteProcuctAsync(int id);
    }
}