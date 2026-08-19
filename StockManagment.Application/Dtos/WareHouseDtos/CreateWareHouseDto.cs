using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Dtos.WareHouseDtos
{
    public class CreateWareHouseDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public string? Location { get; set; }
    }
}
