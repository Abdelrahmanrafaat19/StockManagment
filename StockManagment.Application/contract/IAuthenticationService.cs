using StockManagment.Application.common;
using StockManagment.Application.Dtos.IDentityDTOS;
using StockManagment.Application.Services;
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
        Task<Result<PresentationLoginDto>> LoginUser(SignInDto dto, CancellationToken cancellationToken = default!);
    }
}
