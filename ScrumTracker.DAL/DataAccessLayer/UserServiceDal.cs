using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.RequestEntity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
using ScrumTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class UserServiceDal : IUserServiceDal
    {
        private readonly ApplicationDBContext _context;

        public UserServiceDal(ApplicationDBContext context)
        {
            _context = context;
        }
        #region DailyScrum
        public async Task<ResponseEntity<List<EmpScrumStatusEntity>>> GetAllUserStatus()
        {
            var userstatus = await _context.EmpScrumStatus.ToListAsync();
            return new ResponseEntity<List<EmpScrumStatusEntity>>
            {
                Result=userstatus,
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }
        public async Task<ResponseEntity<IEnumerable<EmpWorkTypeEntity>>> GetAllWorkType()
        {
            var connection = _context.Database.GetDbConnection();
            var worktype = await connection.QueryAsync<EmpWorkTypeEntity>("SpGetWorkTypes", commandType: CommandType.StoredProcedure);
            return new ResponseEntity<IEnumerable<EmpWorkTypeEntity>>
            {
                Result = worktype.ToList(),
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }
        public async Task<ResponseEntity<List<EmpStatusViewEntity>>> GetByDepartment(string department)
        {
            var connection = _context.Database.GetDbConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Department", department, DbType.String);
            var employees = await connection.QueryAsync<EmpDetailsEntity>("SpGetNamesByDepartment", parameters, commandType: CommandType.StoredProcedure);

            var employeeViews = employees.Select(e => new EmpStatusViewEntity
            {
                EmpName = e.EmpName,
                EmpCode = e.EmpCode
            }).ToList();
            return new ResponseEntity<List<EmpStatusViewEntity>>
            {
                Result = employeeViews,
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }
        public async Task<ResponseEntity<int>> PostScrumStatusData(EmpStatusResponseEntity updatestatus)
        {
            try
            {
                var existingUpdateStatus = await _context.EmpScrumStatus
                  .Where(x => x.EmpStatusId == updatestatus.EmpStatusId).FirstOrDefaultAsync();
                if (existingUpdateStatus != null)
                {
                    existingUpdateStatus.EmpDetailId = updatestatus.EmpDetailId;
                    existingUpdateStatus.EmpTask = updatestatus.EmpTask;
                    existingUpdateStatus.EmpWorkTypeId = updatestatus.EmpWorkTypeId;
                    existingUpdateStatus.Billable = updatestatus.GetBillableTime();
                    existingUpdateStatus.NonBillable=updatestatus.GetNonBillableTime();
                    existingUpdateStatus.IsPresent= updatestatus.IsPresent;
                    _context.EmpScrumStatus.UpdateRange(existingUpdateStatus);
                }
                else
                {
                    var updateStatusEntity = new EmpScrumStatusEntity()
                    {
                        EmpDetailId = updatestatus.EmpDetailId,
                        EmpTask = updatestatus.EmpTask,
                        EmpWorkTypeId = updatestatus.EmpWorkTypeId,
                        Billable =updatestatus.GetBillableTime(),
                        NonBillable = updatestatus.GetNonBillableTime(),
                        IsPresent = updatestatus.IsPresent,
                    };
                    _context.EmpScrumStatus.AddRange(updateStatusEntity);
                }
                await _context.SaveChangesAsync(default);
                return new ResponseEntity<int>
                {
                    Result = existingUpdateStatus?.EmpStatusId ?? updatestatus.EmpStatusId,
                    IsSuccess = true,
                    ResponseMessage = existingUpdateStatus == null ? "Data Created successfully." : "Data Updated successfully.",
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
        #endregion

        #region TaskOverview
        public async Task<ResponseEntity<List<EmpSearchStatusViewEntity>>> SearchEmpScrumStatus(string? searchTerm,DateTime? date)
        {
            var connection = _context.Database.GetDbConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@SearchTerm", searchTerm, DbType.String);
            parameters.Add("@Date", date, DbType.Date);

            var employees = await connection.QueryAsync<EmpSearchStatusViewEntity>("SpSearchEmpScrumStatus", parameters, commandType: CommandType.StoredProcedure);

            return new ResponseEntity<List<EmpSearchStatusViewEntity>>
            {
                Result = employees.ToList(),
                IsSuccess = true,
                ResponseMessage = "Data Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }

        #endregion
    }
}

