using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.IDentityDTOS;


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

        public async Task<Result<RoleDto>> CreateRole(string name, CancellationToken cancelationToken = default)
        {
            var result = await _identityService.CreateRole(name, cancelationToken);
            if (!result.IsSuccess)
            {
                return Result<RoleDto>.Failure(result.Error);
            }

            return Result<RoleDto>.Success(result.Value);
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

        public async Task<Result<ProfileDto>> GetCurrentUser(string email, CancellationToken cancellationToken = default)
        {
            var result = await _identityService.GetCurrentUser(email, cancellationToken);
            if (!result.IsSuccess) 
            {
                return Result<ProfileDto>.Failure(result.Error);
            }

            return Result<ProfileDto>.Success(result.Value);

        }

        public async Task<Result<PresentationLoginDto>> LoginUser(SignInDto dto, CancellationToken cancellationToken = default)
        {
            var result =await _identityService.SignInAsync(dto, cancellationToken);
            if (!result.IsSuccess)
            {
                return Result<PresentationLoginDto>.Failure(result.Error);
            }

            var role = await _identityService.GetUserRolesByEmailAsync(dto.Email);

            var token = _jwtTokenCreator.CreateToken(result.Value.Email, result.Value.UserName, result.Value.Id, Array.Empty<string>(), cancellationToken);
            
            return Result<PresentationLoginDto>.Success(new PresentationLoginDto
            {
                Id = result.Value.Id,
                Email= result.Value.Email,
                PhoneNumber= result.Value.PhoneNumber,
                DisplayName= result.Value.DisplayName,
                UserName = result.Value.UserName,
                Token = token
            });
        }
    }
}
