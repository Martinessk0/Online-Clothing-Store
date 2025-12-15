using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Category;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<CategoryDto>> All()
        {
            var result = await _categoryService.GetAllCategories();

            return result;
        }


        [HttpPost]
        public async Task<Category> Create(CategoryCreateDto model)
        {
            var result = await _categoryService.CreateCategory(model);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<Category> Edit(int id, [FromBody] CategoryCreateDto model)
        {
            var result = await _categoryService.EditCategory(id, model);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategory(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
