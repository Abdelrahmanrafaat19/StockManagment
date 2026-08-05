using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Domain.Entity
{
    public class StockItems : BaseEntity<int>
    {
        public Products Products { get; set; } = default!;

        public int ProductsId { get; set; }
        public WorkHouse workHouse { get; set; }=default!;
        public int WorkHouseId { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
