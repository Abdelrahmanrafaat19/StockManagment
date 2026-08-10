using Microsoft.AspNetCore.Http;
using StockManagment.Application.contract;



namespace StockManagment.Application.Services
{
    public class ImageService : IImageService
    {
      
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB

       

        public async Task<string?> SaveImageAsync(IFormFile? file, string folder)
        {
            if (file == null || file.Length == 0)
                return null;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
                throw new InvalidOperationException("Unsupported file type. Allowed: jpg, jpeg, png, webp.");

            if (file.Length > MaxFileSizeBytes)
                throw new InvalidOperationException("File too large. Max size is 5MB.");

            var uploadsRoot = Path.Combine("wwwroot", "uploads", folder);
            Directory.CreateDirectory(uploadsRoot);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsRoot, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // return the relative path we'll store in DB and serve later
            return $"/uploads/{folder}/{fileName}";
        }
    }
}
   

