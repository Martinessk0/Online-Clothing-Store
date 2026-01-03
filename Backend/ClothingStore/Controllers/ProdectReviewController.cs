using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.ProductReview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/reviews")]
public class ProductReviewController : ControllerBase
{
    private readonly IProductReviewService service;

    public ProductReviewController(IProductReviewService service)
    {
        this.service = service;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateReviewDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        await service.CreateAsync(dto, userId);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, UpdateReviewDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        await service.UpdateAsync(id, dto, userId);
        return NoContent();
    }

    [HttpGet("product/{productId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByProduct(int productId)
    {
        return Ok(await service.GetByProductAsync(productId));
    }

    [HttpPatch("{id}/visibility")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetVisibility(int id, bool isVisible)
    {
        await service.SetVisibilityAsync(id, isVisible);
        return NoContent();
    }
}
