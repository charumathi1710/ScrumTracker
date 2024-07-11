using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.Models;

namespace ScrumTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServiceController : ControllerBase
    {
        private IUnitofWork UnitOfWork { get; }
        public UserServiceController(IUnitofWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet("GetUserByDept")]
        public async Task<ActionResult<List<UserMasterEntity>>> GetByDepartment([FromQuery] string department)
        {
            var result = await UnitOfWork.UserServiceBal.GetByDepartment(department);
            return Ok(result);
        }
        [HttpGet("GetAllUserStatus")]
        public async Task<ActionResult<List<UserStatusEntity>>> GetAllUserStatus()
        {
            var result = await UnitOfWork.UserServiceBal.GetAllUserStatus();
            return Ok(result);
        }
    }
}
