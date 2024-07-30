using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class EmpProjectDal:IEmpProjectDal
    {
        private readonly ApplicationDBContext _context;

        public EmpProjectDal(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ResponseEntity<List<EmpProjectResponseEntity>>> GetAllProject()
        {
            var connection = _context.Database.GetDbConnection();
            var project = await connection.QueryAsync<EmpProjectResponseEntity>("spGetCountOfProjects", commandType: CommandType.StoredProcedure);
            var projectViews = project.Select(e => new EmpProjectResponseEntity
            {
                CountOfFixedBid = e.CountOfFixedBid,
                CountOfTimeMaterial = e.CountOfTimeMaterial,
                CountOfRetainer = e.CountOfRetainer,
            }).ToList();

            return new ResponseEntity<List<EmpProjectResponseEntity>>
            {
                Result = projectViews,
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }
        public async Task<ResponseEntity<int>> PostProject(EmpProjectEntity empProject)
        {
            try
            {
                var existingProject = await _context.EmployeeProject
                    .FirstOrDefaultAsync(x => x.EmpProjectID == empProject.EmpProjectID);

                if (existingProject != null)
                {
                    existingProject.EmpDetailsID = empProject.EmpDetailsID;
                    existingProject.FixedBid = empProject.FixedBid;
                    existingProject.TimeMaterial = empProject.TimeMaterial;
                    existingProject.Retainer = empProject.Retainer;
                    existingProject.UpdatedAt = DateTime.UtcNow;
                    _context.EmployeeProject.Update(existingProject);
                }
                else
                {
                    _context.EmployeeProject.Add(empProject);
                }

                await _context.SaveChangesAsync();

                return new ResponseEntity<int>
                {
                    Result = existingProject?.EmpProjectID ?? empProject.EmpProjectID,
                    IsSuccess = true,
                    ResponseMessage = existingProject == null ? "Data Created successfully." : "Data Updated successfully.",
                    StatusMessage = HttpStatusCode.OK.ToString(),
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new ResponseEntity<int>
                {
                    Result = 0,
                    IsSuccess = false,
                    ResponseMessage = ex.Message,
                    StatusMessage = HttpStatusCode.InternalServerError.ToString(),
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }
    }
}
