using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Dtos.ProductDtos
{
    public class ProductDto
    {
        public string ProductCode { get; set; }

      
        public string ProductName { get; set; }

        public string? Description { get; set; }

     
        public decimal UnitePrice { get; set; }

        public int UniteQuantity { get; set; }

        public string UnitOfMeasure { get; set; } 

        public int ReorderLevel { get; set; }

       
        public int CategoryId { get; set; }

        public String? Image { get; set; }
    }
}
