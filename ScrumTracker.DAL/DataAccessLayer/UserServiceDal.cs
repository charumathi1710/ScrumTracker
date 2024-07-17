using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
using ScrumTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class UserServiceDal : IUserServiceDal
    {
        private readonly ApplicationDBContext _context;

        public UserServiceDal(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ResponseEntity<List<EmpDetailEntity>>> GetAllUserStatus()
        {
            var userstatus = await _context.EmpDetails.ToListAsync();
            return new ResponseEntity<List<EmpDetailEntity>>
            {
                Result=userstatus,
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }
        public async Task<ResponseEntity<List<UserStatusViewEntity>>> GetByDepartment(string department)
        {
            var connection = _context.Database.GetDbConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Department", department, DbType.String);

            var employees = await connection.QueryAsync<EmpDetailEntity>("spGetNamesByDepartment", parameters, commandType: CommandType.StoredProcedure);

            var employeeViews = employees.Select(e => new UserStatusViewEntity
            {
                EmpName = e.EmpName,
                EmpCode = e.EmpCode
            }).ToList();

            return new ResponseEntity<List<UserStatusViewEntity>>
            {
                Result = employeeViews,
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }


    }
}

