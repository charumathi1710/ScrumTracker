using Dapper;
using Microsoft.EntityFrameworkCore;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.ResponseEntity;
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
        public async Task<List<UserMasterViewEntity>> GetByDepartment(string department)
        {
            var connection = _context.Database.GetDbConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Department", department, DbType.String);

            var employees = await connection.QueryAsync<UserMasterViewEntity>("spGetNamesByDepartment", parameters, commandType: CommandType.StoredProcedure);
            var employeeDtos = employees.Select(e => new UserMasterViewEntity
            {
                Name = e.Name,
                Emp_Code = e.Emp_Code
            }).ToList();

           return employeeDtos;            
        }
    }
}
