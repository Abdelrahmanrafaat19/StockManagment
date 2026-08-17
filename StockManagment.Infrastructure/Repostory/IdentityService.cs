using Microsoft.AspNetCore.Identity;
using StockManagment.Application.common;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.IDentityDTOS;
using StockManagment.Infrastructure.IdentityData;
using System.Text.RegularExpressions;

namespace StockManagment.Infrastructure.Repostory
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplictionUser> _user;

        public IdentityService(UserManager<ApplictionUser> User)
        {
            _user = User;
        }

        public async Task<Result<IReadOnlyList<string>>> GetUserRolesByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result<IReadOnlyList<string>>.Failure(
                   Error.Validation("ErrorType.Validation", "Email is required."));
            }

            var user = await _user.FindByEmailAsync(email.Trim());

            if (user is null)
            {
                return Result<IReadOnlyList<string>>.Failure(
                    Error.NotFound("ErrorType.NotFound", "This user does not exist."));
            }

            var roles = await _user.GetRolesAsync(user);
            if (roles is null || roles.Count <= 0)
            {
                return Result<IReadOnlyList<string>>.Failure(
                    Error.NotFound("ErrorType.NotFound", "This user havenot Roles."));
            }

            return Result<IReadOnlyList<string>>.Success(
                roles.ToList());
        }

        public async Task<Result<SignInReturnedDto>> SignInAsync(SignInDto dto, CancellationToken cancellationToken)
        {
            var result =  await _user.FindByEmailAsync(dto.Email);

            if (result is null)
            {
                return Result<SignInReturnedDto>.Failure(Error.Unauthorized("ErrorType.Unauthorized", "Email is not Exist"));
            }


            var checkPassword = await _user.CheckPasswordAsync(result, dto.Password);

            if (!checkPassword)
            {
                return Result<SignInReturnedDto>.Failure(Error.Unauthorized("ErrorType.Unauthorized", "Password is not correc"));
            }


            return Result<SignInReturnedDto>.Success(new SignInReturnedDto()
            {
                Id = result.Id,
                DisplayName = result.DisplayName,
                UserName= result.UserName!,
                Email=  result.Email!,
                PhoneNumber= result.PhoneNumber!

            });
            
        }

        public async Task<Result<SignUpCreatedDto>> SignUpAsync(SignUpDtos dto, CancellationToken cancellationToken)
        {
            var resultCheckEmailExist = await _user.FindByEmailAsync(dto.Email);
            Regex _regex = new Regex(@"^01[0-2,5]{1}[0-9]{8}$");
            #region Check Email Is Exist Or Not
            if (resultCheckEmailExist is not null)
            {
                return Result<SignUpCreatedDto>.Failure(Error.Conflict("ErrorType.Conflict", "This Email is Already Exist"));
            }

            #endregion
            #region Phone Number Validation
            if (!_regex.IsMatch(dto.PhoneNumber))
            {
                return Result<SignUpCreatedDto>.Failure(Error.Validation("ErrorType.Validation", "Invalid Phone Number Format"));
            } 
            #endregion
            var newUser = new ApplictionUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DisplayName = dto.DisplayName
            };

            var createResult = await _user.CreateAsync(newUser, dto.Password);
            #region Check User Created Or Not
            if (!createResult.Succeeded)
            {
                var errors = createResult.Errors.Select(e => e.Description).ToList();
                var errorMessage = string.Join(", ", errors);
                return Result<SignUpCreatedDto>.Failure(Error.Validation("ErrorType.Validation", errorMessage));

            } 
            #endregion

            return Result<SignUpCreatedDto>.Success(new SignUpCreatedDto
            {
               Id = newUser.Id,
                UserName = newUser.UserName,
                Email = newUser.Email,
                PhoneNumber = newUser.PhoneNumber,
                DisplayName = newUser.DisplayName
            });
        }
    }
}