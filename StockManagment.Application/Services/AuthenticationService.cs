using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.IDentityDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtTokenCreator _jwtTokenCreator;
        public AuthenticationService(IIdentityService identityService , IJwtTokenCreator jwtTokenCreator)
        {
            _identityService = identityService;
            _jwtTokenCreator = jwtTokenCreator;
        }
        public async Task<Result<PresentationUserCreatedDtos>> CreateUser(SignUpDtos dto, CancellationToken cancellationToken =default!)
        {
            var result =await _identityService.SignUpAsync(dto, cancellationToken);
            
           if(!result.IsSuccess)
           {
                return Result<PresentationUserCreatedDtos>.Failure(result.Error);
           }
           
           var role = await _identityService.GetUserRolesByEmailAsync(dto.Email);
           
           var token = _jwtTokenCreator.CreateToken(result.Value.Email,result.Value.UserName,result.Value.Id, Array.Empty<string>(),cancellationToken);
        
           return Result<PresentationUserCreatedDtos>.Success(new PresentationUserCreatedDtos
           {
               Email = result.Value.Email,
               UserName = result.Value.UserName,
               Token = token
           });

        }
    }
}
