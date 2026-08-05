using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Domain.Entity
{
    public class WorkHouse : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? Location { get; set; }
        public ICollection<StockItems> StockItems { get; set; } = new List<StockItems>();
    }
}
