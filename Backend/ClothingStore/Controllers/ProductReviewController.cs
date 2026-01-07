using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.ProductReview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
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
        await service.CreateReviewAsync(dto, userId);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, UpdateReviewDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        await service.UpdateReviewAsync(id, dto, userId);
        return NoContent();
    }

    [HttpGet("product/{productId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByProduct(
    int productId,
    [FromQuery] bool includeHidden = false)
    {
        return Ok(await service.GetByProductAsync(productId, includeHidden));
    }

    [HttpPatch("{id}/visibility")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetVisibility(int id, bool isVisible)
    {
        await service.SetVisibilityAsync(id, isVisible);
        return NoContent();
    }

    [HttpGet("can-review/{productId}")]
    [Authorize]
    public async Task<IActionResult> CanReview(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var canReview = await service.CanReviewAsync(productId, userId);

        return Ok(new { canReview });
    }
}
