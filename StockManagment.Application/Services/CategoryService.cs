using AutoMapper;
using Microsoft.Extensions.Options;
using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.CatogryDtos;
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

        public async Task<Result<IReadOnlyList<CategoryDto>>> GetAllCategoriesAsync(CancellationToken ct = default)
        {
            var result= await uniteOfWork.GetRepositor<int , Category>().GetAllAsync(ct);
            var theEndResult = result.Select(category => new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            }).ToList();
            return Result<IReadOnlyList<CategoryDto>>.Success(theEndResult);
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

        public async Task<Result<CategoryDto>> UpdateCategoryByIdAsync(int id, CreateCategoryDto createCategoryDto, CancellationToken ct = default)
        {
            var CategoryResult=await uniteOfWork.GetRepositor<int, Category>().GetById(id, ct);
            if(CategoryResult is null)
            {
                return Result<CategoryDto>.Failure(
                              Error.NotFound(
                                  "Categories.NotFound",
                                  "Category not found."));
            }
            // Update the category properties here
            CategoryResult.Name = createCategoryDto.Name;
            CategoryResult.Description = createCategoryDto.Description;
            CategoryResult.UpdatedAt = DateTime.UtcNow;
            await uniteOfWork.SaveChangesAsync(ct);
            return Result<CategoryDto>.Success(new CategoryDto()
            {
                Id = CategoryResult.Id,
                Name = CategoryResult.Name,
                Description = CategoryResult.Description,
                CreatedAt = CategoryResult.CreatedAt,
                UpdatedAt = CategoryResult.UpdatedAt
            });
        }
    }
}
