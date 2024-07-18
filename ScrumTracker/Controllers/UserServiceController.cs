using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.CustomLayer;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.RequestEntity;
using ScrumTracker.DataObject.ResponseEntity;
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
        #region DailyScrum
        [Tags("Daily Scrum")]
        [HttpGet("GetUserByDept")]
        public async Task<ActionResult<List<UserMasterEntity>>> GetByDepartment([FromQuery] string department)
        {
            var result = await UnitOfWork.UserServiceBal.GetByDepartment(department);
            return Ok(result);
        }
        [Tags("Daily Scrum")]
        [HttpGet("GetAllUserStatus")]
        public async Task<ActionResult<List<EmpScrumStatusEntity>>> GetAllUserStatus()
        {
            var result = await UnitOfWork.UserServiceBal.GetAllUserStatus();
            return Ok(result);
        }
        [Tags("Daily Scrum")]
        [HttpGet("GetAllWorkType")]
        public async Task<ActionResult<List<EmpDetailsEntity>>> GetAllWorkType()
        {
            var result = await UnitOfWork.UserServiceBal.GetAllWorkType();
            return Ok(result);
        }
        [Tags("Daily Scrum")]
        [HttpPost("InsertEmpScrumStatus")]
        public async Task<IActionResult> InsertScrumStatus([FromBody] EmpStatusResponseEntity model)
        {
            var result = await UnitOfWork.UserServiceBal.PostScrumStatusData(model);
            return new JsonResult(new
            {
                EmpScrumStatusEntity = result.Result,
                result.IsSuccess,
                result.ResponseMessage,
                result.StatusMessage,
                result.StatusCode,
            });
        }
        #endregion

        #region TaskOverview
        [Tags("TaskOverview")]
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string? searchTerm, DateTime? date)
        {
            var response = await UnitOfWork.UserServiceBal.SearchEmpScrumStatus(searchTerm,date);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return StatusCode(response.StatusCode, response);
        }
        #endregion
    }
}
