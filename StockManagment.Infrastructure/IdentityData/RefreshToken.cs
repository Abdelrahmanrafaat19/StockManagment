using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Infrastructure.IdentityData
{
    public class RefreshToken 
    {
        public int Id { get; set; } = default!;
        public string TokenHash { get; set; } = default!;
        public DateTime ExpiredDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; } = default!;

        public ApplictionUser User { get; set; } = default!;
    }

}
