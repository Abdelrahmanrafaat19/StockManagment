using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Dtos.IDentityDTOS
{
    public class PresentationUserCreatedDtos
    {
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Token { get; set; } = default!;

    }
}
