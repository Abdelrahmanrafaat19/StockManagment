using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.contract
{
    public interface IJwtTokenCreator
    {
        public string CreateToken(string email, string userName, string id, IReadOnlyList<string> Roles, CancellationToken cancellationToken = default!);
    }
}
