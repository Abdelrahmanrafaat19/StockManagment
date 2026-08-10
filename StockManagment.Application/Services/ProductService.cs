using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.ProductDtos;
using StockManagment.Domain.Contracts;
using StockManagment.Domain.Entity;

namespace StockManagment.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IImageService _imageService;

        public ProductService(IUniteOfWork uniteOfWork, IImageService imageService)
        {
            _uniteOfWork = uniteOfWork;
            _imageService = imageService;
        }

        public async Task<Result<ProductDto>> CreateProductAsync(CreateProductRequest createProductData, CancellationToken ct = default!)
        {
            string? imageURL;
            try
            {
                imageURL = await _imageService.SaveImageAsync(createProductData.Image,"ProductsImages");



            }
            catch(Exception ex)
            {
                return Result<ProductDto>.Failure(
                             Error.Failure(
                                 "Product.BadRequest",
                                 $"{ex.Message}"));
            }

            var product = new Products()
            {
                ProductCode = createProductData.ProductCode,
                ProductName = createProductData.ProductName,
                Description = createProductData.Description,
                UnitePrice = createProductData.UnitePrice,
                UniteQuantity = createProductData.UniteQuantity,
                UnitOfMeasure = createProductData.UnitOfMeasure,
                ReorderLevel = createProductData.ReorderLevel,
                CategoryId = createProductData.CategoryId,
                ImageUrl = imageURL
            };

            await _uniteOfWork.GetRepositor<int, Products>().AddAsync(product, ct);
            var result = await _uniteOfWork.SaveChangesAsync(ct);
            if (result == 0)
            {
                return Result<ProductDto>.Failure(
                         Error.Failure(
                             "Product.BadRequest",
                             "Failed to create product."));
            }


            var ProductResult = new ProductDto()
            {
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Description = product.Description,
                UnitePrice = product.UnitePrice,
                UniteQuantity = product.UniteQuantity,
                UnitOfMeasure = product.UnitOfMeasure,
                ReorderLevel = product.ReorderLevel,
                CategoryId = product.CategoryId,
                Image = product.ImageUrl
            };
            return Result<ProductDto>.Success(ProductResult);
        }
    }
}
