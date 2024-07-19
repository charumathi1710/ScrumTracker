using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.CustomLayer;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.Models;

namespace ScrumTracker.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpProjectController : ControllerBase
    {
        private IUnitofWork UnitofWork;
        public EmpProjectController(IUnitofWork unitofWork)
        {
            UnitofWork = unitofWork;
        }
        [HttpGet("GetAllProject")]
        public async Task<ActionResult<List<UserMasterEntity>>> GetAllProject()
        {
            var result = await UnitofWork.EmpProjectBal.GetAllProject();
            return Ok(result);
        }
        [Authorize(Policy ="PC")]
        [HttpPost("PostProject")]
        public async Task<IActionResult> PostProject([FromBody] EmpProjectEntity model)
        {
            if (ModelState.IsValid)
                return new JsonResult(await UnitofWork.EmpProjectBal.PostProject(model));
            else
                return BadRequest(model);
        }
    }
}
