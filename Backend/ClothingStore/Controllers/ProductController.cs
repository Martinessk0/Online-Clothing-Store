using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Product;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<AuthController> _logger;
        public ProductController(IProductService productService, ILogger<AuthController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var product = await _productService.CreateProductAsync(productDTO);

                var productDto = new ProductDTO
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,                    
                };

                return CreatedAtAction(
                    nameof(GetById),                   
                    new { id = product.Id },            
                    productDto                      
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                return StatusCode(500, "An error occurred while creating the product.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            try
            {                
                await _productService.UpdateProductAsync(id, productDTO);

                return NoContent();                                         
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product with ID {Id}", id);
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all products.");
                return StatusCode(500, new { message = "An error occurred while fetching products." });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productDto = await _productService.GetByIdAsync(id);
            if (productDto == null) return NotFound();
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _productService.DeleteProductAsync(id);

                if (!deleted)
                {
                    _logger.LogWarning("Attempted to delete product with ID {Id}, but it was not found or already inactive.", id);
                    return NotFound(new { message = $"Product with ID {id} not found." });
                }

                _logger.LogInformation("Product with ID {Id} deleted successfully.", id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting product with ID {Id}.", id);
                return StatusCode(500, new { message = "An error occurred while deleting the product." });
            }
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter([FromBody] ProductFilterDTO filterDTO)
        {
            try
            {
                var filteredProducts = await _productService.FilterAsync(filterDTO);

                // Optional: map to DTO if you don't want to return entities directly
                var result = filteredProducts.Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Brand = p.Brand,
                    CategoryId = p.CategoryId,
                    Variants = p.Variants
                                .Where(v => v.IsActive)
                                .Select(v => new ProductVariantDTO
                                {
                                    Id = v.Id,
                                    ColorId = v.ColorId,
                                    ColorName = v.Color.Name,
                                    Size = v.Size,
                                    Stock = v.Stock
                                }).ToList(),
                    Images = p.Images
                                .OrderBy(i => i.SortOrder)
                                .Select(i => new ProductImageDto
                                {
                                    Id = i.Id,
                                    Url = i.Url,
                                    IsMain = i.IsMain
                                }).ToList()
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error filtering products");
                return StatusCode(500, "An error occurred while filtering products.");
            }
        }

    }
}
