using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using ScrumTracker.BAL.CustomLayer;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.RequestEntity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.Models;

namespace ScrumTracker.API.Controllers
{
    //[Authorize]
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
        public async Task<IActionResult> SearchEmpScrumStatus(string? searchTerm, DateTime? date)
        {
            var responseEntity = await UnitOfWork.UserServiceBal.SearchEmpScrumStatus(searchTerm, date);
            if (responseEntity.IsSuccess)
            {
                var stream = new MemoryStream();
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Employees");

                    worksheet.Cells[1, 1].Value = "EmployeeName";
                    worksheet.Cells[1, 2].Value = "EmployeeCode";
                    worksheet.Cells[1, 3].Value = "EmployeeTask";
                    worksheet.Cells[1, 4].Value = "WorkType";
                    worksheet.Cells[1, 5].Value = "Billable";
                    worksheet.Cells[1, 6].Value = "NonBillable";

                    // Adding Data
                    for (int i = 0; i < responseEntity.Result.Count; i++)
                    {
                        var employee = responseEntity.Result[i];
                        worksheet.Cells[i + 2, 1].Value = employee.EmpName;
                        worksheet.Cells[i + 2, 2].Value = employee.EmpCode;
                        worksheet.Cells[i + 2, 3].Value = employee.EmpTask;
                        worksheet.Cells[i + 2, 4].Value = employee.WorkType;
                        worksheet.Cells[i + 2, 5].Value = employee.Billable;
                        worksheet.Cells[i + 2, 6].Value = employee.NonBillable;
                    }

                    package.Save();
                }
                stream.Position = 0;
                var content = stream.ToArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "Employees.xlsx";

               // return File(content, contentType, fileName);
                return Ok(responseEntity);
            }            
            return StatusCode(responseEntity.StatusCode, responseEntity);
        }
    }
    #endregion
}
