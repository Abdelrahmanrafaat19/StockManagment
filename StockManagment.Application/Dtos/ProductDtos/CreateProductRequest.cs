using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Dtos.ProductDtos
{
    public class CreateProductRequest
    {
        [Required]
        public string ProductCode { get; set; } = default!;

        [Required]
        public string ProductName { get; set; } = default!;

        public string? Description { get; set; }

        [Required]
        public decimal UnitePrice { get; set; }

        public int UniteQuantity { get; set; }

        public string UnitOfMeasure { get; set; } = "pcs";

        public int ReorderLevel { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IFormFile? Image { get; set; }
    }
}
