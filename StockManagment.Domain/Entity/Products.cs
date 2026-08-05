using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Domain.Entity
{
    public  class Products : BaseEntity<int>
    {
        public string ProductCode { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public string? Description { get; set; } = default!;
       
        public decimal UnitePrice { get; set; } = default!;
        public int UniteQuantity { get; set; } = default!;
        public string UnitOfMeasure { get; set; } = "pcs";
        public int ReorderLevel { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Category Category { get; set; } = default!;
        public int CategoryId { get; set; } = default!;
        public ICollection<StockItems> StockItems { get; set; } = new List<StockItems>();

    }
}
