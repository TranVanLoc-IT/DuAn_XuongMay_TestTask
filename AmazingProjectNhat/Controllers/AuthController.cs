using AmazingProjectNhat.Entity;
using AmazingProjectNhat.Repository.AuthRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazingProjectNhat.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            string verify = _authRepository.AuthenticateUser(userLogin);
            if (verify == null)
            { 
                return StatusCode(500, new { message = "Server Error: Unable to authenticate user." }); 
            }
            else if (verify.Equals("Wrong Username"))
            { 
                return Unauthorized(new { message = "Wrong Username" }); 
            }
            else if (verify.Equals("Wrong Password."))
            { 
                return Unauthorized(new { message = "Wrong Password" }); 
            }
            return Ok(verify);
        }
    }
}
