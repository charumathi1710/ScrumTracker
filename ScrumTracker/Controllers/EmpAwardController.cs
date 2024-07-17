using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.CustomLayer;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.RequestEntity;
using ScrumTracker.DataObject.ViewEntity;
using ScrumTracker.Models;

namespace ScrumTracker.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAwardController : ControllerBase
    {
        private IUnitofWork UnitofWork;
        public EmpAwardController(IUnitofWork unitofWork)
        {
            UnitofWork = unitofWork;
        }
        [HttpGet("GetUserAwardByMonthAndYear")]
        public async Task<ActionResult<List<UserMasterEntity>>> GetByUserAwardByMonthAndYear([FromQuery] string month,int year)
        {
            var result = await UnitofWork.UserAwardBal.GetByUserAwardByMonthAndYear(month,year);
            return Ok(result);
        }
        [Authorize(Policy = "PC")]
        [HttpPost("InsertUserAward")]
        public async Task<IActionResult> InsertUserAward(EmpAwardRequestEntity model)
        {
            if (ModelState.IsValid)
                return new JsonResult(await UnitofWork.UserAwardBal.SendDataToUserAward(model));
            else
                return BadRequest(model);
        }
        [Authorize(Policy = "PC")]
        [HttpDelete]
        public async Task<IActionResult> RemoveData(int userAwardId)
        {
            return new JsonResult(await UnitofWork.UserAwardBal.RemoveDataFromUserAward(userAwardId));
        }
    }
}
