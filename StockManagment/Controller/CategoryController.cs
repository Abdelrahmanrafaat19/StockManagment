using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos;

namespace StockManagment.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto, CancellationToken ct = default)
        {
            var result = await categoryService.CreateCategoryAsync(createCategoryDto, ct);
            return HandleCreatedResult<CategoryDto>(
                result,
                nameof(GetCategoryById),
                  category => new
                  {
                      id = category.Id
                  });
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id, CancellationToken ct = default)
        {
            var result = await categoryService.GetCategoryByIdAsync(id, ct);
            return HandleResult(result);
        }

    }
}
