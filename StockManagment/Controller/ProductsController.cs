using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.ProductDtos;

namespace StockManagment.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _ProductService;
        public ProductsController(IProductService productService)
        {
            _ProductService = productService;
        }



        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request)
        {
            var result = await _ProductService.CreateProductAsync(request);
            return HandleCreatedResult<ProductDto>(result);

        }
    }
}
