using API_DAPPER.Models.Requests;
using API_DAPPER.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_DAPPER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repository.GetCategoriesAsync();
            return categories.Any() ? Ok(categories) : NoContent();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repository.GetCategoryAsync(id);
            return category != null ? Ok(category) : NotFound("Categoria não foi encontrada");
        }

        [HttpPost]
        public async Task<ActionResult> PostCategory(CategoryRequest request)
        {
            if(string.IsNullOrEmpty(request.Name))
            {
                return BadRequest("As informações inseridas são inválidas !");
            }
            var add = await _repository.AddCategoryAsync(request);
            return add ? Ok("Categoria  adicionada com sucesso") : BadRequest("Erro ao adicionar a categoria, tente novamente mais tarde.");
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutCategory(CategoryRequest request, int id)
        {
            if(id <= 0 ) return BadRequest("O Id informado é inválido");
            
            var category  = await _repository.GetCategoryAsync(id);

            if(category  == null) return NotFound("A categoria que você deseja editar não existe!");

            if(string.IsNullOrEmpty(request.Name)) request.Name = category.Name;

            var put = await _repository.UpdateCategoryAsync(request, id);

            return put ? Ok("Categoria atualizada com sucesso") : BadRequest("Erro ao atualizar categoria");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if(id <= 0 ) BadRequest("Categoria inexistente!");

            var category = await _repository.GetCategoryAsync(id);

            if(category == null) NotFound("Categoria não foi encontrada");

            var delete = await _repository.DeleteCategoryAsync(id);

            return delete ? Ok("Categoria foi apagado com sucesso!") : BadRequest("Erro ao apagar categoria!");

        }
    }
}