using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Cloudinary;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ICloudinaryService cloudinaryService;

        public ImageController(ICloudinaryService cloudinaryService)
        {
            this.cloudinaryService = cloudinaryService;
        }

        [HttpPost("product")]
        [RequestSizeLimit(20_000_000)] // ~20MB
        public async Task<ActionResult<ImageUploadResultDto>> UploadProductImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty.");
            }

            try
            {
                var result = await cloudinaryService.UploadImageAsync(file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error uploading image.", error = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage([FromQuery] string publicId)
        {
            if (string.IsNullOrEmpty(publicId))
            {
                return BadRequest("publicId is required.");
            }

            var success = await cloudinaryService.DeleteImageAsync(publicId);

            if (!success)
            {
                return StatusCode(500, new { message = "Error deleting image." });
            }

            return NoContent();
        }
    }
}
