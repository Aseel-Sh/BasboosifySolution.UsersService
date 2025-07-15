using Basboosify.Core.DTO;
using Basboosify.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basboosify.API.Controllers
{
    // api/auth
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _usersService;

        public AuthController(IUserService usersService)
        {
            _usersService = usersService;
        }

        //POST api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            //check for invalid register req
            if (registerRequest == null)
            {
                return BadRequest("Invalid registeration request");
            }

            //call the userservice to handle registration
            AuthenticationResponse? authResponse = await _usersService.Register(registerRequest);

            if (authResponse == null || authResponse.Success == false) 
            {
                return BadRequest(authResponse);
            }

            return Ok(authResponse);
        }

        //POST api/auth/register
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid login request");
            }

            AuthenticationResponse authResponse = await _usersService.Login(loginRequest);

            if (authResponse == null || authResponse.Success == false )
            {
                return Unauthorized(authResponse);
            }

            return Ok(authResponse);
        }
    }
}
