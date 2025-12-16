using ClothingStore.Core.Models.Cloudinary;
using Microsoft.AspNetCore.Http;


namespace ClothingStore.Core.Contracts
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResultDto> UploadImageAsync(IFormFile file);
        Task<bool> DeleteImageAsync(string publicId);
    }
}
