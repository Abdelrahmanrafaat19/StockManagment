using AutoMapper;
using StockManagment.Application.Dtos.WareHouseDtos;
using StockManagment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Profiles
{
    public class WareHouseProfile : Profile
    {
        public WareHouseProfile()
        {
            CreateMap<WorkHouse, GetWareHouseDto>().ReverseMap();
        }
    }
}
