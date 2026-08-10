using StockManagment.Application.common;
using StockManagment.Application.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.contract
{
    public interface IProductService
    {
        Task<Result<ProductDto>> CreateProductAsync(CreateProductRequest createProductData, CancellationToken ct = default!);

    }
}
