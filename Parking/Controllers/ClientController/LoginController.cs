using Microsoft.AspNetCore.Mvc;
using Parking.DTO.Login;
using Parking.Servicess.AuthService;

namespace Parking.Controllers.ClientController
{


    [ApiController]
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {

        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.identification) || string.IsNullOrEmpty(request.password))
            {
                return BadRequest(new LoginResponse { Message = "Invalid request" });
            }

            var (token, client) = await _authService.AuthenticateAsync(request.identification, request.password);

            if (token == null || client == null)
            {
                return Unauthorized(new LoginResponse { Message = "Invalid username or password" });
            }

            return Ok(new LoginResponse { Token = token, User = client, Message = "Login successful" });
        }
    }
}
