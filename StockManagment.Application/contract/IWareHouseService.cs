using StockManagment.Application.common;
using StockManagment.Application.Dtos.WareHouseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.contract
{
    public interface IWareHouseService
    {
        Task<Result<IReadOnlyList<GetWareHouseDto>>> GetAllWareHouses(CancellationToken ct = default!);
        Task<Result<GetWareHouseDto>> CreateWareHouse(CreateWareHouseDto createDto, CancellationToken ct = default!);
    }
}
