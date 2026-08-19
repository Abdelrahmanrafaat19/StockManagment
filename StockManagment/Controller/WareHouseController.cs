using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.WareHouseDtos;
using StockManagment.Application.Services;

namespace StockManagment.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : BaseApiController
    {
        private readonly IWareHouseService _wareHouseService;
        public WareHouseController(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAllWareHouse() 
        {
            var result = await _wareHouseService.GetAllWareHouses();
            return HandleResult(result);
        }
        [HttpPost("CreateWareHouse")]
        public async Task<IActionResult> CreateWareHouse(CreateWareHouseDto createDto)
        {
            var result = await _wareHouseService.CreateWareHouse(createDto);
            return HandleResult(result);
        }
    }
}
