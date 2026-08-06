using AutoMapper;
using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos;
using StockManagment.Domain.Contracts;
using StockManagment.Domain.Entity;


namespace StockManagment.Application.Services
{
    public class CategoryService(IUniteOfWork uniteOfWork ) : ICategoryService
    {
        public async Task<Result<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto ,CancellationToken ct=default)
        {
            if (string.IsNullOrWhiteSpace(createCategoryDto.Name))
            {
                return Result<CategoryDto>.Failure(
                    Error.Validation(
                        "Categories.NameRequired",
                        "Category name is required."));
            }
            var categoryExists = await uniteOfWork.GetRepositor<int, Category>().GetByName(category=>category.Name == createCategoryDto.Name, ct);
            if (categoryExists is not null)
            {

                return Result<CategoryDto>.Failure(
                  Error.Conflict(
                      "Categories.conflict",
                      "Category name is Exist."));
            }


            var Category = new Category()
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await uniteOfWork.GetRepositor<int, Category>().AddAsync(Category, ct);
            
            var result = await uniteOfWork.SaveChangesAsync(ct);
            
            if (result > 0)
            {
                var categoryDto = new CategoryDto()
                {
                    Name = createCategoryDto.Name,
                    Description = createCategoryDto.Description,
                    CreatedAt = DateTime.UtcNow
                };
                return Result<CategoryDto>.Success(categoryDto);
            }
            else
            {
                return Result<CategoryDto>.Failure(
                    Error.Validation(
                        "Categories.CreateFailed",
                        "Failed to create category."));
            }
        }

        public async Task<Result<CategoryDto>> GetCategoryByIdAsync(int id, CancellationToken ct = default)
        {
            var result =await uniteOfWork.GetRepositor<int, Category>().GetById(id, ct);
            if(result is null)
            {
                return Result<CategoryDto>.Failure(
                              Error.NotFound(
                                  "Categories.NotFound",
                                  "Category not found."));
            }

            return Result<CategoryDto>.Success(new CategoryDto()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            });
        }
    }
}
