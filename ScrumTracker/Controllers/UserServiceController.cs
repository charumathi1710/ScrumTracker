using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.Models;

namespace ScrumTracker.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserServiceController : ControllerBase
    {
        private IUnitofWork UnitOfWork { get; }
        public UserServiceController(IUnitofWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet("GetUserServiceByDepartment")]
        public async Task<ActionResult<List<UserMasterViewEntity>>> GetByDepartment([FromQuery] string department)
        {
            var result = await UnitOfWork.UserServiceBal.GetByDepartment(department);
            return Ok(result);
        }
    }
}
