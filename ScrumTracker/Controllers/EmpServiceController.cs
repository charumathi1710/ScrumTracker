using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;

namespace ScrumTracker.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpServiceController : ControllerBase
    {
        private IUnitofWork UnitOfWork { get; }
        public EmpServiceController(IUnitofWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        [Tags("Employee Management")]
        [HttpGet("EmpDetailsGetALL")]
        public async Task<ActionResult<List<EmpDetailsEntity>>> GetAllEmpDetails()
        {
            var employees = await UnitOfWork.EmpServiceBal.GetAllEmpDetails();
            return Ok(employees);
        }
        [Tags("Employee Management")]
        [HttpGet("EmpDetailsGetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var result= await UnitOfWork.EmpServiceBal.GetEmpDetailById(id);
            return Ok(result);
        }
        [Authorize(Policy = "PC")]
        [Tags("Employee Management")]
        [HttpPost("PostEmployee")]
        public async Task<IActionResult> InsertScrumStatus([FromBody] EmpDetailsResponseEntity model)
        {
            var result = await UnitOfWork.EmpServiceBal.PostData(model);
            return new JsonResult(new
            {
                EmpDetailsEntity = result.Result,
                result.IsSuccess,
                result.ResponseMessage,
                result.StatusMessage,
                result.StatusCode,
            });
        }
        [Authorize(Policy = "PC")]
        [Tags("Employee Management")]
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await UnitOfWork.EmpServiceBal.DeleteData(id);
            return Ok(result);
        }
    }
}
