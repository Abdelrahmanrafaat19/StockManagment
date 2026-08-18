using StockManagment.Application.common;
using StockManagment.Application.Dtos.IDentityDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.contract
{
    public interface IIdentityService
    {
        Task<Result<SignUpCreatedDto>> SignUpAsync(SignUpDtos dto , CancellationToken cancellationToken);
        Task<Result<IReadOnlyList<string>>> GetUserRolesByEmailAsync(string email);
        Task<Result<SignInReturnedDto>> SignInAsync(SignInDto dto, CancellationToken cancellationToken);
        Task<Result<RoleDto>> CreateRole(string name, CancellationToken cancelationToken = default!);
        Task<Result<ProfileDto>>  GetCurrentUser(string email, CancellationToken cancellationToken = default!);
    }
}
