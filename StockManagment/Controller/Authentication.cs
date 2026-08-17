
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.contract;
using StockManagment.Application.Dtos.IDentityDTOS;

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
    }
}
