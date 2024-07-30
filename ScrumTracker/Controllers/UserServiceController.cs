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
                return Ok(responseEntity);
            }
            return StatusCode(responseEntity.StatusCode, responseEntity);
        }

        [Tags("Excel")]
        [HttpGet("DownloadExcel")]
        public async Task<IActionResult> DownloadExcelFile(string? searchTerm, DateTime? date)
        {
            var responseEntity = await UnitOfWork.UserServiceBal.SearchEmpScrumStatus(searchTerm, date);
            if (responseEntity.IsSuccess)
            {
                var stream = new MemoryStream();
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Employees");

                    // Define headers
                    var headers = new List<string> { "EmployeeName", "EmployeeCode", "EmployeeTask", "WorkType", "Billable", "NonBillable" };

                    // Add headers to worksheet
                    for (int i = 0; i < headers.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = headers[i];
                    }

                    // Set header style
                    using (var headerRange = worksheet.Cells[1, 1, 1, headers.Count])
                    {
                        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        headerRange.Style.Font.Bold = true;
                    }

                    // Add data to worksheet
                    var employees = responseEntity.Result.Select((employee, index) => new { employee, index }).ToList();
                    foreach (var emp in employees)
                    {
                        worksheet.Cells[emp.index + 2, 1].Value = emp.employee.EmpName;
                        worksheet.Cells[emp.index + 2, 2].Value = emp.employee.EmpCode;
                        worksheet.Cells[emp.index + 2, 3].Value = emp.employee.EmpTask;
                        worksheet.Cells[emp.index + 2, 4].Value = emp.employee.WorkType;
                        worksheet.Cells[emp.index + 2, 5].Value = emp.employee.Billable;
                        worksheet.Cells[emp.index + 2, 6].Value = emp.employee.NonBillable;
                    }

                    package.Save();
                }
                stream.Position = 0;
                var content = stream.ToArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "Employees.xlsx";

                return File(content, contentType, fileName);
            }
            else
            {
                // Handle error case appropriately, e.g., log error, notify user, etc.
                return StatusCode(responseEntity.StatusCode, responseEntity);
            }
        }
        #endregion
    }
}
