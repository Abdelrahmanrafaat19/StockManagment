using AutoMapper;
using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.WareHouseDtos;
using StockManagment.Domain.Contracts;
using StockManagment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Services
{
    public class WareHouseService : IWareHouseService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public WareHouseService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetWareHouseDto>> CreateWareHouse(CreateWareHouseDto createDto, CancellationToken ct = default)
        {
            var newWareHouse = new WorkHouse()
            {
                Name = createDto.Name,
                Description = createDto.Description,
                Location = createDto.Location,
            };
            await _uniteOfWork.GetRepositor<int, WorkHouse>().AddAsync(newWareHouse, ct);
            var result = await _uniteOfWork.SaveChangesAsync(ct);
            if(result <= 0)
            {
                return Result<GetWareHouseDto>.Failure( Error.Failure("ErrorType.Failure", "Failed to create warehouse."));
            }
            var createdWareHouse = new GetWareHouseDto()
            {
                Name = createDto.Name,
                Description = createDto.Description,
                Location = createDto.Location,
                CreatedAt = newWareHouse.CreatedAt,
            };

            return Result<GetWareHouseDto>.Success(createdWareHouse);
        }

        public async Task<Result<IReadOnlyList<GetWareHouseDto>>> GetAllWareHouses(CancellationToken ct = default)
        {
            var wareHouses = await _uniteOfWork.GetRepositor<int , WorkHouse>().GetAllAsync(ct);
            var wareHouseDtos = _mapper.Map<IReadOnlyList<GetWareHouseDto>>(wareHouses);
            return Result<IReadOnlyList<GetWareHouseDto>>.Success(wareHouseDtos);
        }
    }
}
