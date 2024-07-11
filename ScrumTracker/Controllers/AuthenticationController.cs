using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.RequestEntity;

namespace ScrumTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUnitofWork unitOfWork;

        public AuthenticationController(IUnitofWork unitofWork)
        {
            unitOfWork = unitofWork;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] TokenRequestEntity request)
        {
            var user = unitOfWork.AuthenticationBal.GetUserByUsernameAndPassword(request.Username, request.Password, request.RoleName);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokens = unitOfWork.RefreshTokenBal.GenerateTokens(user);
            return Ok(tokens);
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] string refreshToken)
        {
            var tokens = unitOfWork.RefreshTokenBal.RefreshToken(refreshToken);
            if (tokens == null)
            {
                return Unauthorized();
            }
            return Ok(tokens);
        }
    }
}
