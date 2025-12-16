using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Cloudinary;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> settings)
        {
            var cfg = settings.Value;

            var account = new Account(
                cfg.CloudName,
                cfg.ApiKey,
                cfg.ApiSecret
            );

            cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResultDto> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty.");
            }

            await using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "products"
            };

            var result = await cloudinary.UploadAsync(uploadParams);

            if (result.Error != null)
            {
                throw new InvalidOperationException(result.Error.Message);
            }

            return new ImageUploadResultDto
            {
                Url = result.SecureUrl.ToString(),
                PublicId = result.PublicId
            };
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);

            var result = await cloudinary.DestroyAsync(deletionParams);

            return result.Result == "ok";
        }
    }
}
