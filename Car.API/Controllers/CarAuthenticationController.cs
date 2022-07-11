using Car.API.IdentityManager;
using Microsoft.AspNetCore.Mvc;

namespace Car.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarAuthenticationController: ControllerBase
    {

        private readonly IUserService _userService;
        public CarAuthenticationController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest authenticateRequest)
        {
            var response = _userService.Authenticate(authenticateRequest);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
