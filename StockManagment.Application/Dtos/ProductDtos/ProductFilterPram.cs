using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Dtos.ProductDtos
{
    public class ProductFilterPram
    {
        public string? ProductCode { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public int? CategoryId { get; set; } 

    }
}
