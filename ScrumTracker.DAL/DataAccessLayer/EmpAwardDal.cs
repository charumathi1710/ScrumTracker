using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class EmpAwardDal : IEmpAwardDal
    {
        private readonly ApplicationDBContext _context;

        public EmpAwardDal(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ResponseEntity<List<EmpAwardResponseEntity>>> GetByUserAwardByMonthAndYear(string month,int year)
        {
            var connection = _context.Database.GetDbConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Month", month, DbType.String);
            parameters.Add("@Year", year, DbType.Int64);

            var employees = await connection.QueryAsync<EmpAwardResponseEntity>("spGetUserAwardByMonthAndYear", parameters, commandType: CommandType.StoredProcedure);
            var employeeViews = employees.Select(e => new EmpAwardResponseEntity
            {
                EmpAwardID= e.EmpAwardID,
                EmpDetailId= e.EmpDetailId,
                Month= e.Month,
                Year= e.Year,
                EmpName = e.EmpName,
                EmpDept = e.EmpDept
            }).ToList();

            return new ResponseEntity<List<EmpAwardResponseEntity>>
            {
                Result = employeeViews,
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }

        public async Task<ResponseEntity<EmpAwardResponseEntity>> SendDataToUserAward(EmpAwardEntity model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                int empAwardID = model.EmpAwardID;

                EmpAwardEntity entity;

                if (empAwardID == 0)
                {
                    await _context.EmployeeAward.AddAsync(model);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    entity = model;
                }
                else
                {
                    entity = await _context.EmployeeAward.FirstOrDefaultAsync(x => x.EmpAwardID == empAwardID); // Use the original ID for lookup
                    if (entity == null)
                    {
                        return new ResponseEntity<EmpAwardResponseEntity>
                        {
                            IsSuccess = false,
                            ResponseMessage = $"Invalid {empAwardID} ID! Try Again.",
                            StatusMessage = HttpStatusCode.NotFound.ToString(),
                            StatusCode = StatusCodes.Status404NotFound,
                        };
                    }

                    var patchData = new JsonPatchDocument<EmpAwardEntity>()
                        .Replace(s => s.EmpDetailId, model.EmpDetailId)
                        .Replace(s => s.Month, model.Month)
                        .Replace(s => s.Year, model.Year)
                        .Replace(s => s.UpdatedAt, model.UpdatedAt);
                    patchData.ApplyTo(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }

                var employee = await _context.EmployeeDetails.FirstOrDefaultAsync(e => e.EmpDetailId == entity.EmpDetailId);
                if (employee == null)
                {
                    return new ResponseEntity<EmpAwardResponseEntity>
                    {
                        IsSuccess = false,
                        ResponseMessage = "Employee not found.",
                        StatusMessage = HttpStatusCode.NotFound.ToString(),
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

                var responseEntity = new EmpAwardResponseEntity
                {
                    EmpAwardID = entity.EmpAwardID,
                    EmpDetailId = entity.EmpDetailId,
                    Month = entity.Month,
                    Year = entity.Year,
                    EmpName = employee.EmpName,
                    EmpDept = employee.EmpDept
                };

                return new ResponseEntity<EmpAwardResponseEntity>
                {
                    Result = responseEntity,
                    IsSuccess = true,
                    ResponseMessage = empAwardID == 0 ? "UserAward created successfully." : "UserAward updated successfully.",
                    StatusMessage = empAwardID == 0 ? HttpStatusCode.Created.ToString() : HttpStatusCode.OK.ToString(),
                    StatusCode = empAwardID == 0 ? StatusCodes.Status201Created : StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new ResponseEntity<EmpAwardResponseEntity>
                {
                    Result = null,
                    IsSuccess = false,
                    ResponseMessage = ex.Message,
                    StatusMessage = HttpStatusCode.InternalServerError.ToString(),
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }

        public async Task<ResponseEntity<bool>> RemoveDataFromUserAward(int Id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var dacpData = await _context.EmployeeAward.FirstOrDefaultAsync(x => x.EmpAwardID == Id);

                if (dacpData == null)
                {
                    return new ResponseEntity<bool>
                    {
                        Result = false,
                        IsSuccess = false,
                        ResponseMessage = $"Invalid {Id} Id! Try Again.",
                        StatusMessage = HttpStatusCode.OK.ToString(),
                        StatusCode = StatusCodes.Status200OK,
                    };
                }

                _context.EmployeeAward.Remove(dacpData);
                await _context.SaveChangesAsync(default);
                await transaction.CommitAsync();

                return new ResponseEntity<bool>
                {
                    Result = true,
                    IsSuccess = true,
                    ResponseMessage = new HttpResponseMessage(HttpStatusCode.Accepted).RequestMessage?.ToString(),
                    StatusMessage = HttpStatusCode.OK.ToString(),
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return new ResponseEntity<bool>
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message,
                    StatusMessage = HttpStatusCode.InternalServerError.ToString(),
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }

    }
}
