using StockManagment.Application.common;
using StockManagment.Application.Dtos.IDentityDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.contract
{
    public interface IAuthenticationService
    {
        Task<Result<PresentationUserCreatedDtos>> CreateUser(SignUpDtos dto, CancellationToken cancellationToken = default!);
    }
}
