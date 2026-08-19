using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Dtos.WareHouseDtos
{
    public class GetWareHouseDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? Location { get; set; }
    }
}
