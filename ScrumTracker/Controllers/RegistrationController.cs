using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;

namespace ScrumTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationBal _userRepository;
        private readonly ApplicationDBContext _context;

        public RegistrationController(IRegistrationBal userRepository, ApplicationDBContext context)
        {
            _userRepository = userRepository;
            this._context = context;
        }
        [Tags("Authentication Token")]
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserTokenViewEntity userView)
        {
            if (userView == null || string.IsNullOrEmpty(userView.Username) || string.IsNullOrEmpty(userView.Password))
            {
                return BadRequest("Invalid user data.");
            }

            var existingUser = await _context.UserToken
                                             .FirstOrDefaultAsync(u => u.Username == userView.Username);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Username already exists." });
            }

            var user = new UserTokenEntity
            {
                Username = userView.Username,
                Password = userView.Password,
                RoleID = userView.UserRoleID
            };

            var createdUser = await _userRepository.AddUserAsync(user);
            var userResponse = new UserTokenResponseEntity
            {
                UsersTokenId = createdUser.UsersTokenId,
                Username = createdUser.Username,
                Password = createdUser.Password,
                CreationDate= createdUser.CreationDate,
                HostName=createdUser.HostName,
                UpdatedAt= createdUser.UpdatedAt,
            };
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UsersTokenId }, userResponse);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok();
        }
    }
}
