using API_DAPPER.Models.Requests;
using API_DAPPER.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_DAPPER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var product = await _repository.GetProductsAsync();
            return product.Any() ? Ok(product): NoContent();  
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            var product = await _repository.GetProductAsync(Id);
            return product != null ? Ok(product) : NotFound("Produto não encontrado!");

        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductRequest request)
        {
            if(string.IsNullOrEmpty(request.Name))
            {
                return  BadRequest("Informações inseridas são inválidas !");
            }

            var post = await _repository.AddProductAsync(request);

            return post? Ok("Produto inserido com sucesso !") : BadRequest("Erro na requisição !");
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductRequest request, int Id)
        {
            if(Id <= 0) return BadRequest("Produto inválido!");

            var product = await _repository.GetProductAsync(Id);

            if(product == null) return NotFound("Produto não encontrado!");

            if(string.IsNullOrEmpty(request.Name)) request.Name = product.Name;
            
            var put = await _repository.UpdateProductAsync(request, Id);

            return put ? Ok("Atualizado com sucesso !") : BadRequest("Erro ao atualizar !");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if(id <= 0) return BadRequest("Produto inexistente !");
            
            var product = await _repository.GetProductAsync(id);

            if(product == null) NotFound("Produto não existe");

            var delete = await _repository.DeleteProcuctAsync(id);

            return delete ? Ok("Produto deletado com sucesso") : BadRequest("Não foi possível deletar o produto!"); 
        }
    }
}