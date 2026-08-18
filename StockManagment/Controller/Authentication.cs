
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.IDentityDTOS;
using System.Security.Claims;

namespace StockManagment.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : BaseApiController
    {
        private readonly IAuthenticationService _authenticationService;
        public Authentication(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDtos dto)
        {
            var result = await _authenticationService.CreateUser(dto);
            return HandleResult(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto dto)
        {
            var result = await _authenticationService.LoginUser(dto);
            return HandleResult(result);
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] string rolename)
        {
            var result = await _authenticationService.CreateRole(rolename);
            return HandleResult(result);
        }
        [Authorize]
        [HttpGet("GetCurrentUser")]
       
        public async Task<IActionResult> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await _authenticationService.GetCurrentUser(email!);
            return HandleResult(result);
        }
    }
}
