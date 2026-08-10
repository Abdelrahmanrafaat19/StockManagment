
using StockManagment.Application.common;
using StockManagment.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.contract
{
    public interface ICategoryService
    {
        Task<Result<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto , CancellationToken ct=default);
        Task<Result<CategoryDto>> GetCategoryByIdAsync(int id , CancellationToken ct=default);
        Task<Result<CategoryDto>> UpdateCategoryByIdAsync(int id ,CreateCategoryDto createCategoryDto, CancellationToken ct=default);
        Task<Result<IReadOnlyList<CategoryDto>>> GetAllCategoriesAsync(CancellationToken ct=default);
    }
}
